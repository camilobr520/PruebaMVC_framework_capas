using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public partial class LibrosModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "*Requerido")]
        [Range(1111111, 999999999999, ErrorMessage = "Fuera del rango")]
        public long ISBN { set; get; }

        public int Editoriales_id { set; get; }

        [MaxLength(5,ErrorMessage ="Máximo 5 caracteres")]
        [Required(ErrorMessage = "Name is required")]
        public string Titulo { set; get; }
        [Required]
        [StringLength(50)]
        public string Sinopsis { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string N_paginas { set; get; }

        //este objeto editoriales viene directamente del ado framework model
        [Required(ErrorMessage = "Name is required")]
        public virtual editoriales Editoriales { set; get; }



    }
}
