using System;
using System.Collections.Generic;

#nullable disable

namespace Productos.Models
{
    public partial class Autenticacion
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Activo { get; set; }
        public string Token { get; set; }
    }
}
