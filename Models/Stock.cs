using System;
using System.Collections.Generic;

#nullable disable

namespace Productos.Models
{
    public partial class Stock
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int? PrecioUnitario { get; set; }
    }
}
