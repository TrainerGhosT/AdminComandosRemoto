using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Models
{
    [Serializable]
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; }              // Nombre descriptivo del servidor
        public string IP { get; set; }                // Dirección IP del servidor
        public string Username { get; set; }          // Usuario de conexión SSH
        public string EncryptedPassword { get; set; } // Contraseña encriptada
        public List<Commands> Commands { get; set; } = new List<Commands>(); // Lista de comandos asociados

        // Constructor vacío requerido para serialización
        public Server()
        {
            Id = Guid.NewGuid(); // Asignar ID automáticamente
            Commands = new List<Commands>();
        }

        // Constructor con parámetros para facilitar la creación
        public Server(string name, string ip, string username, string encryptedPassword)
        {
            Id = Guid.NewGuid(); // Asignar ID automáticamente
            Name = name;
            IP = ip;
            Username = username;
            EncryptedPassword = encryptedPassword;
            Commands = new List<Commands>();
        }
    }
}