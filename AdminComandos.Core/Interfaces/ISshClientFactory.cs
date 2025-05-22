using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Interfaces
{
    public interface ISshClientFactory
    {
        ISshClient Create(string host, string username, string password);
    }
}
