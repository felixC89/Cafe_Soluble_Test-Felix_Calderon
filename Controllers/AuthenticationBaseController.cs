using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationBaseController : ControllerBase
    {
        public bool VerifyToken(HttpRequestMessage autenticador)
        {
            string token_auth = "";

            foreach (var item in autenticador.Headers)
            {
                if (item.Key.Equals("Authorization"))
                {
                    token_auth = item.Value.First();

                    break;
                }
                else
                {
                    return false;
                }
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
    }
}
