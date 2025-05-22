using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Interfaces
{
   public interface ISshService
    {
        string Encrypt(string plainText);

        string ExecuteCommand(Server server, string commandText);

        string Decrypt(string encryptedText);

    }
}
