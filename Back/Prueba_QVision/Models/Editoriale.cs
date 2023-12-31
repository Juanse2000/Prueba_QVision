﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_QVision.Models
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdEditorial { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
