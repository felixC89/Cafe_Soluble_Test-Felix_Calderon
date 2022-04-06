using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Productos.RequestObjects
{
    public class ReplyStockLst
    {
        public int Estatus { get; set; }

        public string Msg { get; set; }

        public List<Stock> Data { get; set; }
    }
}
