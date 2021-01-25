using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public partial class EditorialesModel
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Sede { set; get; }

        public virtual ICollection<LibrosModel> Libros { get; set; }
    }
}
