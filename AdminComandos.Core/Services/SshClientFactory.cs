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
            return new RenciSshClientWrapper(new SshClient(host, username, password));
        }


    }
}
