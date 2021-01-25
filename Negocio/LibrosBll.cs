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
   public class LibrosBll
    {
        public Respuesta GetLibros()
        {
            using (
                
                
                ViajemosEntities db = new ViajemosEntities())
            {
                
                Respuesta respuesta = new Respuesta();
           
                List<LibrosModel> lst = (from d in db.libros

                                    select new LibrosModel
                                    {
                                        Titulo = d.titulo,
                                        Sinopsis = d.sinopsis,
                                        N_paginas = d.n_paginas,
                                        Id = d.id,
                                        ISBN = d.ISBN,
                                        Editoriales = d.editoriales,
                                        Editoriales_id = d.editoriales_id
                                    }).ToList();

                respuesta.Data = lst;
                respuesta.Success = 1;
                return respuesta;
            }
        }

        public Respuesta GetLibrosId(int id)
        {
            using (


                ViajemosEntities db = new ViajemosEntities())
            {

                Respuesta respuesta = new Respuesta();

                LibrosModel libro = (from d in db.libros
                                         where d.id==id
                                         select new LibrosModel
                                         {
                                             Titulo = d.titulo,
                                             Sinopsis = d.sinopsis,
                                             N_paginas = d.n_paginas,
                                             Id = d.id,
                                             ISBN = d.ISBN,
                                             Editoriales = d.editoriales,
                                             Editoriales_id = d.editoriales_id
                                         }).ToList().FirstOrDefault();

                respuesta.Data = libro;
                respuesta.Success = 1;
                return respuesta;
            }
        }

        public Respuesta AddLibros(LibrosModel model)
        {
            using (ViajemosEntities db = new ViajemosEntities())
            {
                Respuesta respuesta = new Respuesta();
                //objeto olibro viene del modelo del ado.entityFramework
                libros olibro = new libros();
                olibro.ISBN = model.ISBN;
                olibro.titulo = model.Titulo;
                olibro.sinopsis = model.Sinopsis;
                olibro.n_paginas = model.N_paginas;
                olibro.editoriales_id = model.Editoriales_id;
                db.libros.Add(olibro);
                db.SaveChanges();
                respuesta.Success = 1;
                //aquí devuelve la lista de libros, la diferencia con GetLibros es que esta consulta no incluye el objeto editoriales.
                List < libros >lst= db.libros.ToList();
                respuesta.Data = lst;
                return respuesta;
            }
        }
        public Respuesta EditLibros(LibrosModel model)
        {
            using (ViajemosEntities db = new ViajemosEntities())
            {
                Respuesta respuesta = new Respuesta();
                 //traigo el objeto de la base que voy a modificar en olibro
                libros olibro = db.libros.Find(model.Id);
             
                olibro.ISBN = model.ISBN;
                olibro.titulo = model.Titulo;
                olibro.sinopsis = model.Sinopsis;
                olibro.n_paginas = model.N_paginas;
                olibro.editoriales_id = model.Editoriales_id;
                db.Entry(olibro).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                respuesta.Success = 1;
                //aquí devuelve la lista de libros, la diferencia con GetLibros es que esta consulta no incluye el objeto editoriales.
                List<libros> lst = db.libros.ToList();
                respuesta.Data = lst;
                return respuesta;
            }
        }
        public Respuesta DeleteLibros(LibrosModel model)
        {
            using (ViajemosEntities db = new ViajemosEntities())
            {
                Respuesta respuesta = new Respuesta();
                //traigo el objeto de la base que voy a modificar en olibro
                libros olibro = db.libros.Find(model.Id);
                db.libros.Remove(olibro);
                db.SaveChanges();
                respuesta.Success = 1;
                //aquí devuelve la lista de libros, la diferencia con GetLibros es que esta consulta no incluye el objeto editoriales.
                List<libros> lst = db.libros.ToList();
                respuesta.Data = lst;
                return respuesta;
            }
        }
    }
}
