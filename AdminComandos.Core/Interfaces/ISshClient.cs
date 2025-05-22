using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Interfaces
{
    public interface ISshClient : IDisposable
    {
        void Connect();
        SshCommand CreateCommand(string commandText);
        void Disconnect();
    }
}
