using System;
using System.Collections.Generic;

#nullable disable

namespace Todolist_App.Models
{
    public partial class Tarea
    {
        public int IdTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public bool? EstadoTarea { get; set; }
    }
}
