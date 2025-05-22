using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Interfaces
{
    public interface IStorageRepository
    {
        IReadOnlyList<Server> LoadAllServers();
        void SaveAllServers(IEnumerable<Server> servers);
        Server GetServerById(Guid id);
        void SaveServer(Server server);
        bool DeleteServer(Guid id);
        Commands GetCommandById(Guid id);
        void SaveCommand(Commands command, Server server);
        bool DeleteCommand(Guid id);
    }
}
