using AdminComandos.Core.Interfaces;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISshClient = AdminComandos.Core.Interfaces.ISshClient;

namespace AdminComandos.Core.Services
{
    public class SshClientFactory : ISshClientFactory
    {
        public ISshClient Create(string host, string username, string password)
        {
            // Determinar el puerto (por defecto 22)
            int port = 22;
            string actualHost = host;

            // Si el host contiene puerto (formato host:puerto), separarlo
            if (host.Contains(':'))
            {
                var parts = host.Split(':');
                actualHost = parts[0];
                if (parts.Length > 1 && int.TryParse(parts[1], out int parsedPort))
                {
                    port = parsedPort;
                }
            }

            var sshClient = new SshClient(actualHost, port, username, password);

            // Configurar timeout
            sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(30);

            return new RenciSshClientWrapper(sshClient);
        }
    }
}
