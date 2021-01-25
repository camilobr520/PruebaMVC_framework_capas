using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Datos;
using Modelos.Respuesta;
using Modelos;


namespace Presentacion.Controllers
{
    public class LibrosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

            LibrosBll lb = new LibrosBll();
            ViewBag.listLibros = lb.GetLibros().Data;
            EditoresBll ed = new EditoresBll();
            ViewBag.listEditores = ed.GetEditores().Data;
            return View();
        }

        [HttpPost]
        public ActionResult Add(LibrosModel model)
        {
            LibrosBll lb = new LibrosBll();

            if ((ModelState.IsValid))
            {
                //Si el id ya existe entonces no lo agrego si no que modificó
                if (model.Id == 0)
                {
                    lb.AddLibros(model);
                }
                else
                {
                    lb.EditLibros(model);
                }

            }


            return RedirectToAction("Index");
        }

        public ActionResult Modify(int id)
        {
            EditoresBll ed = new EditoresBll();
            ViewBag.listEditores = ed.GetEditores().Data;
            LibrosBll lb = new LibrosBll();
              //consulto el libro a modificar por id (para no tener que pasar el objeto de una vista a otra)
            var libro=lb.GetLibrosId(id).Data;
            if (libro==null)
            {
                return RedirectToAction("Index");
            }
            return  View(libro);
        }

        public ActionResult Delete(int id)
        {
            LibrosModel olibro = new LibrosModel();
            LibrosBll lb = new LibrosBll();
            try
            {
                olibro.Id = id;
                lb.DeleteLibros(olibro);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}