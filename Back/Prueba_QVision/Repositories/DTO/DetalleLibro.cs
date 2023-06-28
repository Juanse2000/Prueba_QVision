using System.Collections.Generic;

namespace Prueba_QVision.Repositories.DTO
{
    public class DetalleLibro
    {
        public int idLibro { get; set; }
        public string nombreLibro { get; set; }
        public string sinopsis { get; set; }
        public string paginas { get; set; }
        public string editorial { get; set; }
        public string sede { get; set; }
        public List<Autor> autores { get; set; }
    }
}
