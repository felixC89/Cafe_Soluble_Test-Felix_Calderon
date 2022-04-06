using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Models;
using Productos.RequestObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private ProductosContext db = new ProductosContext();

        // GET: api/<StockController>
        [HttpGet]
        public ReplyStockLst Get()
        {
            ReplyStockLst res = new ReplyStockLst();
            res.Estatus = 0;
            res.Msg = "";
            res.Data = null;

            //Se obtienen los headers
            var requestHeaders = HttpContext.Request.Headers;

            if (!VerifyToken(requestHeaders))
            {
                res.Estatus = 1;
                res.Msg = "Error de autenticación";

                return res;
            }

            res.Data = db.Stocks.ToList();
            return res;
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public ReplyStock Get(int id)
        {
            ReplyStock res = new ReplyStock();
            res.Estatus = 0;
            res.Msg = "";
            res.Data = null;

            //Se obtienen los headers
            var requestHeaders = HttpContext.Request.Headers;

            if (!VerifyToken(requestHeaders))
            {
                res.Estatus = 1;
                res.Msg = "Error de autenticación";

                return res;
            }

            Stock stock = db.Stocks.Find(id);

            if (stock == null)
            {
                res.Estatus = 1;
                res.Msg = "Ocurrio un error";
                return res;
            }
            else
            {
                res.Data = stock;
            }

            return res;
        }

        // POST api/<StockController>
        [HttpPost]
        public ReplyStock Post([FromBody] Stock stock)
        {
            ReplyStock res = new ReplyStock();
            res.Estatus = 0;
            res.Msg = "Producto insertado con exito!";
            res.Data = null;

            //Se obtienen los headers
            var requestHeaders = HttpContext.Request.Headers;

            if (!VerifyToken(requestHeaders))
            {
                res.Estatus = 1;
                res.Msg = "Error de autenticación";

                return res;
            }

            if (!ModelState.IsValid)
            {
                res.Estatus = 1;
                res.Msg = "Error al conectar con el origen de datos";

                return res;
            }

            db.Stocks.Add(stock);
            db.SaveChanges();

            res.Data = stock;

            return res;
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public ReplyStock Put(int id, [FromBody] Stock stock)
        {
            ReplyStock res = new ReplyStock();
            res.Estatus = 0;
            res.Msg = "";
            res.Data = null;

            //Se obtienen los headers
            var requestHeaders = HttpContext.Request.Headers;

            if (!VerifyToken(requestHeaders))
            {
                res.Estatus = 1;
                res.Msg = "Error de autenticación";

                return res;
            }

            if (!ModelState.IsValid)
            {
                res.Estatus = 1;
                res.Msg = "Error al conectar con el origen de datos";

                return res;
            }

            if (id != stock.IdProducto)
            {
                res.Estatus = 1;
                res.Msg = "Ocurrió un error";
                return res;
            }

            db.Entry(stock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                res.Data = stock;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
                {
                    res.Estatus = 1;
                    res.Msg = "No se encontró el objeto";
                    return res;
                }
                else
                {
                    throw;
                }
            }

            return res;
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public ReplyStock Delete(int id)
        {
            ReplyStock res = new ReplyStock();
            res.Estatus = 0;
            res.Msg = "Producto eliminado con exito!";
            res.Data = null;

            //Se obtienen los headers
            var requestHeaders = HttpContext.Request.Headers;

            if (!VerifyToken(requestHeaders))
            {
                res.Estatus = 1;
                res.Msg = "Error de autenticación";

                return res;
            }

            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                res.Estatus = 1;
                res.Msg = "No se encontró el objeto";
                return res;
            }

            db.Stocks.Remove(stock);
            db.SaveChanges();
            res.Data = stock;

            return res;
        }

        public static bool VerifyToken(IHeaderDictionary header)
        {
            string token_auth = null;

            foreach (var item in header)
            {
                if (item.Key == "Authorization")
                {
                    token_auth = item.Value.First().ToString();

                    break;
                }
                
            }

            if (token_auth == null) 
            {
                return false;
            }


            using (ProductosContext db = new ProductosContext())
            {
                var lst = db.Autenticacions.Where(d => d.Token == token_auth && d.Activo == "si");

                if (lst.Count() > 0)
                {
                    return true;
                }
            }


            return false;

        }

        private bool StockExists(int id)
        {
            return db.Stocks.Count(e => e.IdProducto == id) > 0;
        }
    }
}
