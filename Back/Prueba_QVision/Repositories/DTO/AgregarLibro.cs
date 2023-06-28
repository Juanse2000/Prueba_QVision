namespace Prueba_QVision.Repositories.DTO
{
    public class infoBasica
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public int? IdEditorial { get; set; }
    }

    public class AgregarLibro
    {
        public infoBasica infoBasica { get; set; }
        public int idAutor { get; set; }
    }
}
