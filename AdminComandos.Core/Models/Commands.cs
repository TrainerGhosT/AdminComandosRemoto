﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    [Serializable]
    public class Commands
    {
        public Guid Id { get; set; }
        public Guid ServerId { get; set; }          // Relación al servidor
        public string Text { get; set; }           // Texto del comando

        // Constructor vacío requerido para serialización
        public Commands()
        {
            Id = Guid.NewGuid(); // Asignar ID automáticamente
        }

        // Constructor con parámetros para facilitar la creación
        public Commands(Guid serverId, string text)
        {
            Id = Guid.NewGuid(); // Asignar ID automáticamente
            ServerId = serverId;
            Text = text;
        }
    }
}