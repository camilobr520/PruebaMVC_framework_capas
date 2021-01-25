using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Modelos;
using Modelos.Respuesta;

namespace Negocio
{
   public class EditoresBll
    {
        public Respuesta GetEditores()
        {
            using (


                ViajemosEntities db = new ViajemosEntities())
            {

                Respuesta respuesta = new Respuesta();
                var lst = db.editoriales.OrderByDescending(d => d.id).ToList();
                respuesta.Data = lst;
                respuesta.Success = 1;
                return respuesta;
            }
        }

    }
}
