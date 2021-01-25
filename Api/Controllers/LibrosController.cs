using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modelos.Respuesta;
using Modelos;
using Negocio;
using Newtonsoft.Json;


namespace Api.Controllers
{
    public class LibrosController : ApiController
    {
        [HttpGet]
        [Route("api/libros")]
        public string GetLibros()
        {
            LibrosBll lb = new LibrosBll();
            
            Respuesta res = lb.GetLibros();
             var jsonString = JsonConvert.SerializeObject(res);
            //var jsonString = Newtonsoft.Json(res);

            return jsonString;
        }
    }
}
