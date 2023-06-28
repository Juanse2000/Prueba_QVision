using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_QVision.Models
{
    public partial class Libro
    {
        public Libro()
        {
            AutoresHasLibros = new HashSet<AutoresHasLibro>();
        }

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? IdEditorial { get; set; }

        public virtual Editoriale IdEditorialNavigation { get; set; }
        public virtual ICollection<AutoresHasLibro> AutoresHasLibros { get; set; }
    }
}
