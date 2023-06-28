using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_QVision.Models
{
    public partial class AutoresHasLibro
    {
        public int IdAutorLibro { get; set; }
        public int? IdAutor { get; set; }
        public int? IdLibro { get; set; }

        public virtual Autore IdAutorNavigation { get; set; }
        public virtual Libro IdLibroNavigation { get; set; }
    }
}
