using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Core.Models;


using AdminComandos.Core.Interfaces;

namespace AdminComandos.Core.Repositories
{

    public class XMLRepository : IStorageRepository
    {
        private readonly string _baseDirectory;
        private readonly string _serverDirectory;
        private readonly XmlSerializer _serializer;

        public XMLRepository(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
            _serverDirectory = Path.Combine(_baseDirectory, "Servers");

            // Crear directorios si no existen
            Directory.CreateDirectory(_baseDirectory);
            Directory.CreateDirectory(_serverDirectory);

            _serializer = new XmlSerializer(typeof(List<Server>));
        }

        private string GetServersFilePath()
        {
            return Path.Combine(_serverDirectory, "servers.xml");
        }

        public IReadOnlyList<Server> LoadAllServers()
        {
            string filePath = GetServersFilePath();

            if (!File.Exists(filePath))
                return new List<Server>();

            try
            {
                using var stream = File.OpenRead(filePath);
                return ((List<Server>)_serializer.Deserialize(stream)).ToList();
            }
            catch (Exception ex)
            {
                // Podemos loguear el error o relanzar con más contexto
                throw new InvalidOperationException($"Error cargando servidores desde XML: {filePath}", ex);
            }
        }

        public void SaveAllServers(IEnumerable<Server> servers)
        {
            string filePath = GetServersFilePath();

            try
            {
                var list = servers.ToList();

                using var writer = new StreamWriter(filePath, false);
                _serializer.Serialize(writer, list);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error guardando servidores en XML: {filePath}", ex);
            }
        }

        public Server GetServerById(Guid id)
        {
            return LoadAllServers().FirstOrDefault(s => s.Id == id);
        }

        public void SaveServer(Server server)
        {
            var servers = LoadAllServers().ToList();
            var existingIndex = servers.FindIndex(s => s.Id == server.Id);

            if (existingIndex >= 0)
                servers[existingIndex] = server;
            else
                servers.Add(server);

            SaveAllServers(servers);
        }

        public bool DeleteServer(Guid id)
        {
            var servers = LoadAllServers().ToList();
            var serverToRemove = servers.FirstOrDefault(s => s.Id == id);

            if (serverToRemove == null)
                return false;

            servers.Remove(serverToRemove);
            SaveAllServers(servers);
            return true;
        }

        public Commands GetCommandById(Guid id)
        {
            return LoadAllServers()
                .SelectMany(s => s.Commands)
                .FirstOrDefault(c => c.Id == id);
        }

        public void SaveCommand(Commands command, Server server)
        {
            var servers = LoadAllServers().ToList();
            var existingServer = servers.FirstOrDefault(s => s.Id == server.Id);

            if (existingServer == null)
            {
                // Si el servidor no existe, lo agregamos con el comando
                server.Commands.Add(command);
                servers.Add(server);
            }
            else
            {
                // Si el servidor existe, actualizamos o agregamos el comando
                var existingCommandIndex = existingServer.Commands.FindIndex(c => c.Id == command.Id);

                if (existingCommandIndex >= 0)
                    existingServer.Commands[existingCommandIndex] = command;
                else
                    existingServer.Commands.Add(command);
            }

            SaveAllServers(servers);
        }

        public bool DeleteCommand(Guid id)
        {
            var servers = LoadAllServers().ToList();
            bool commandDeleted = false;

            foreach (var server in servers)
            {
                var commandToRemove = server.Commands.FirstOrDefault(c => c.Id == id);
                if (commandToRemove != null)
                {
                    server.Commands.Remove(commandToRemove);
                    commandDeleted = true;
                    break;
                }
            }

            if (commandDeleted)
                SaveAllServers(servers);

            return commandDeleted;
        }
    }
}