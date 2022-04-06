using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Models;
using Productos.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpPost]
        public Reply Login([FromBody] Usuario oUser)
        {
            Reply reply = new Reply();
            reply.Estatus = 0;

            using (ProductosContext db = new ProductosContext())
            {
                
                var lst = db.Autenticacions.Where(d => d.Usuario == oUser.usuario && d.Password == oUser.pass && d.Activo == "si");

                if (lst.Count() > 0)
                {
                    var user = lst.First();
                    user.Token = Guid.NewGuid().ToString();
                    reply.Data = user.Token;

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else
                {
                    reply.Estatus = 1;
                    reply.Data = "Ocurrio un error al autenticarse";
                }
            }


            return reply;

        }

      
        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
