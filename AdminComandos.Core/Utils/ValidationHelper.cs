using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdminComandos.Core.Utils
{
    public static class ValidationHelper
    {
        public static bool IsValidIp(string ip) => IPAddress.TryParse(ip, out _);
    }
}
