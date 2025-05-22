using AdminComandos.Core.Interfaces;
using AdminComandos.Core.Utils;
using Core.Models;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Services
{
    public class SshService : ISshService
    {
        private readonly ISshClientFactory _sshClientFactory;

        public SshService(ISshClientFactory sshClientFactory = null)
        {
            _sshClientFactory = sshClientFactory ?? new SshClientFactory();
        }

        public string ExecuteCommand(Server server, string commandText)
        {
            if (server == null) throw new ArgumentNullException(nameof(server));
            if (string.IsNullOrWhiteSpace(commandText)) throw new ArgumentException("El comando no puede estar vacío.");

            try
            {
                // Desencriptar la contraseña
                var password = Decrypt(server.EncryptedPassword);

                // Determinar el puerto (por defecto 22)
                int port = 22;
                string host = server.IP;

                // Si la IP contiene puerto (formato IP:puerto), separarlo
                if (server.IP.Contains(':'))
                {
                    var parts = server.IP.Split(':');
                    host = parts[0];
                    if (parts.Length > 1 && int.TryParse(parts[1], out int parsedPort))
                    {
                        port = parsedPort;
                    }
                }

                using var client = new SshClient(host, port, server.Username, password);

                // Configurar timeout de conexión (30 segundos)
                client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(30);

                client.Connect();

                if (!client.IsConnected)
                {
                    return "ERROR: No se pudo establecer la conexión SSH";
                }

                var cmd = client.CreateCommand(commandText);
                var result = cmd.Execute();

                // Capturar también posibles errores
                var error = cmd.Error;
                client.Disconnect();

                return string.IsNullOrEmpty(error)
                    ? result
                    : $"ERROR: {error}\n{result}";
            }
            catch (Renci.SshNet.Common.SshConnectionException ex)
            {
                return $"Error de conexión SSH: {ex.Message}\nVerifique que el servidor SSH esté ejecutándose y sea accesible.";
            }
            catch (Renci.SshNet.Common.SshAuthenticationException ex)
            {
                return $"Error de autenticación SSH: {ex.Message}\nVerifique las credenciales (usuario/contraseña).";
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                return $"Error de red: {ex.Message}\nVerifique la dirección IP y que el puerto esté abierto.";
            }
            catch (Exception ex)
            {
                return $"Excepción al ejecutar SSH: {ex.Message}";
            }
        }

        public string Encrypt(string plainText)
        {
            return EncryptionHelper.Encrypt(plainText);
        }

        public string Decrypt(string encryptedText)
        {
            return EncryptionHelper.Decrypt(encryptedText);
        }
    }
}
