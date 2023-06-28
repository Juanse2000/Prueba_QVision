using Prueba_QVision.Repositories.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_QVision.Repositories.Interface
{
    public interface ILibreria
    {
        Task<List<Libros>> ObtenerLibros();
        Task<DetalleLibro> ObtenerDetalle(int idLibro);
        Task<object> ObtenerListaEditoriales();
        Task<object> ObtenerListaAutores();
        Task<object> AgregarLibro(AgregarLibro request);
        Task<object> ObtenerLibroPorId(int idLibro);
        Task<object> ActualizarLibro(ActualizarLibro request, int idLibro);
    }
}
