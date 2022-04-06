using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Productos.RequestObjects
{
    public class ReplyStock
    {
        public int Estatus { get; set; }

        public string Msg { get; set; }

        public Stock Data { get; set; }
    }
}
