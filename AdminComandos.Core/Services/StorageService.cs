using AdminComandos.Core.Interfaces;
using AdminComandos.Core.Repositories;
using AdminComandos.Core.Utils;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Services
{
    public class StorageService
    {
        private readonly XMLRepository _repository;
        public StorageService(XMLRepository repo)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /* --- Servicios para los servidores --- */

        /// <summary>
        /// Obtiene todos los servidores
        /// </summary>
        /// <returns>Lista de servidores</returns>
        public List<Server> GetAllServers()
        {
            return _repository.LoadAllServers().ToList();
        }

        /// <summary>
        /// Obtiene un servidor por su ID
        /// </summary>
        /// <param name="id">ID del servidor</param>
        /// <returns>Servidor encontrado o null</returns>
        public Server GetServerById(Guid id)
        {
            return _repository.GetServerById(id);
        }

        /// <summary>
        /// Agrega un nuevo servidor
        /// </summary>
        /// <param name="name">Nombre del servidor</param>
        /// <param name="ip">Dirección IP</param>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">Contraseña (sin encriptar)</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) AddServer(string name, string ip, string username, string password)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(name))
                    return (false, "El nombre del servidor no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(ip))
                    return (false, "La dirección IP no puede estar vacía.");

                //if (!ValidationHelper.IsValidIp(ip))
                //    return (false, "La dirección IP no es válida.");

                if (string.IsNullOrWhiteSpace(username))
                    return (false, "El nombre de usuario no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(password))
                    return (false, "La contraseña no puede estar vacía.");

                // Encriptar contraseña
                string encryptedPassword = EncryptionHelper.Encrypt(password);

                // Crear y guardar servidor
                var server = new Server(name, ip, username, encryptedPassword);
                _repository.SaveServer(server);

                return (true, "Se ha agregado un nuevo servidor.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error agregando el servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Modifica un servidor existente
        /// </summary>
        /// <param name="id">ID del servidor</param>
        /// <param name="name">Nuevo nombre</param>
        /// <param name="ip">Nueva dirección IP</param>
        /// <param name="username">Nuevo nombre de usuario</param>
        /// <param name="password">Nueva contraseña (sin encriptar), null si no se cambia</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) UpdateServer(Guid id, string name, string ip, string username, string password)
        {
            try
            {
                var server = _repository.GetServerById(id);
                if (server == null)
                    return (false, "El servidor no existe.");

                // Validaciones
                if (string.IsNullOrWhiteSpace(name))
                    return (false, "El nombre del servidor no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(ip))
                    return (false, "La dirección IP no puede estar vacía.");

                if (!ValidationHelper.IsValidIp(ip))
                    return (false, "La dirección IP no es válida.");

                if (string.IsNullOrWhiteSpace(username))
                    return (false, "El nombre de usuario no puede estar vacío.");

                // Actualizar datos
                server.Name = name;
                server.IP = ip;
                server.Username = username;

                // Actualizar contraseña solo si se proporciona una nueva
                if (!string.IsNullOrWhiteSpace(password))
                {
                    server.EncryptedPassword = EncryptionHelper.Encrypt(password);
                }

                _repository.SaveServer(server);

                return (true, "Se ha modificado la información del servidor.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error modificando el servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina un servidor
        /// </summary>
        /// <param name="id">ID del servidor</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) DeleteServer(Guid id)
        {
            try
            {
                var server = _repository.GetServerById(id);
                if (server == null)
                    return (false, "El servidor no existe.");

                bool deleted = _repository.DeleteServer(id);

                return deleted
                    ? (true, "El servidor ha sido eliminado correctamente.")
                    : (false, "No se pudo eliminar el servidor.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error eliminando el servidor: {ex.Message}");
            }
        }


        /* --- Servicios para los comandos --- */

        /// <summary>
        /// Obtiene todos los comandos de un servidor
        /// </summary>
        /// <param name="serverId">ID del servidor</param>
        /// <returns>Lista de comandos</returns>
        public List<Commands> GetCommandsByServerId(Guid serverId)
        {
            var server = _repository.GetServerById(serverId);
            return server?.Commands ?? new List<Commands>();
        }

        /// <summary>
        /// Obtiene un comando por su ID
        /// </summary>
        /// <param name="id">ID del comando</param>
        /// <returns>Comando encontrado o null</returns>
        public Commands GetCommandById(Guid id)
        {
            return _repository.GetCommandById(id);
        }

        /// <summary>
        /// Agrega un nuevo comando a un servidor
        /// </summary>
        /// <param name="serverId">ID del servidor</param>
        /// <param name="commandText">Texto del comando</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) AddCommand(Guid serverId, string commandText)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(commandText))
                    return (false, "El comando no puede estar vacío.");

                var server = _repository.GetServerById(serverId);
                if (server == null)
                    return (false, "El servidor no existe.");

                // Crear y guardar comando
                var command = new Commands(serverId, commandText);
                _repository.SaveCommand(command, server);

                return (true, "Se ha agregado un nuevo comando.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error agregando el comando: {ex.Message}");
            }
        }

        /// <summary>
        /// Modifica un comando existente
        /// </summary>
        /// <param name="id">ID del comando</param>
        /// <param name="commandText">Nuevo texto del comando</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) UpdateCommand(Guid id, string commandText)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(commandText))
                    return (false, "El comando no puede estar vacío.");

                var command = _repository.GetCommandById(id);
                if (command == null)
                    return (false, "El comando no existe.");

                var server = _repository.GetServerById(command.ServerId);
                if (server == null)
                    return (false, "El servidor asociado no existe.");

                // Actualizar y guardar comando
                command.Text = commandText;
                _repository.SaveCommand(command, server);

                return (true, "Se ha modificado la información del comando.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error modificando el comando: {ex.Message}");
            }
        }

        /// <summary>
        /// Elimina un comando
        /// </summary>
        /// <param name="id">ID del comando</param>
        /// <returns>Resultado de la operación</returns>
        public (bool Success, string Message) DeleteCommand(Guid id)
        {
            try
            {
                var command = _repository.GetCommandById(id);
                if (command == null)
                    return (false, "El comando no existe.");

                bool deleted = _repository.DeleteCommand(id);

                return deleted
                    ? (true, "El comando ha sido eliminado correctamente.")
                    : (false, "No se pudo eliminar el comando.");
            }
            catch (Exception ex)
            {
                return (false, $"Ha ocurrido un error eliminando el comando: {ex.Message}");
            }
        }
    }
}

