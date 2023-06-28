using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Prueba_QVision.Models;
using Prueba_QVision.Repositories.DTO;
using Prueba_QVision.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_QVision.Repositories.Logic
{
    public class LibreriaLogic : ILibreria
    {
        private readonly LIBRERIA_QVISIONContext _context;
        private readonly IMapper _mapper;

        public LibreriaLogic(LIBRERIA_QVISIONContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Libros>> ObtenerLibros()
        {
            try
            {
                var datos = await (from L in _context.Libros
                                    select new Libros
                                    {
                                        idLibro = L.IdLibro,
                                        nombreLibro = L.Titulo,
                                        sinopsis = L.Sinopsis,
                                        paginas = L.NPaginas
                                    }).ToListAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DetalleLibro> ObtenerDetalle(int idLibro)
        {
            try
            {
                var datosAutores = await ObtenerDetalleAutores(idLibro);
                var datos = await (from L in _context.Libros.Where(x => x.IdLibro == idLibro)
                                   join E in _context.Editoriales on L.IdEditorial equals E.IdEditorial
                                   select new DetalleLibro
                                   {
                                       idLibro = L.IdLibro,
                                       nombreLibro = L.Titulo,
                                       sinopsis = L.Sinopsis,
                                       paginas = L.NPaginas,
                                       editorial = E.Nombre,
                                       sede = E.Sede,
                                       autores = datosAutores
                                   }).FirstOrDefaultAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Autor>> ObtenerDetalleAutores(int idLibro)
        {
            try
            {
                var datos = await (
                                    from L2 in _context.Libros.Where(x => x.IdLibro == idLibro)
                                    join AL in _context.AutoresHasLibros on L2.IdLibro equals AL.IdLibro
                                    join A in _context.Autores on AL.IdAutor equals A.IdAutor
                                    select new Autor
                                    {
                                        nombre = A.Nombre + " " + A.Apellido
                                    }
                                ).ToListAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> ObtenerListaEditoriales()
        {
            try
            {
                var datos = await (from E in _context.Editoriales
                                   select new 
                                   {
                                       idEditorial = E.IdEditorial,
                                       nombre = E.Nombre,
                                   }).ToListAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> ObtenerListaAutores()
        {
            try
            {
                var datos = await (from A in _context.Autores
                                   select new
                                   {
                                       idAutor = A.IdAutor,
                                       nombre = A.Nombre + " " + A.Apellido,
                                   }).ToListAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> AgregarLibro(AgregarLibro request)
        {
            try
            {
                // Se mapea el objeto request(AgregarLibro) a un objeto de la clase Libro para poder insertar los datos
                var datos = _mapper.Map<Libro>(request.infoBasica);

                //Se insertan los datos y se guardan los cambios
                _context.Libros.Add(datos);
                await _context.SaveChangesAsync();

                //Se consulta el ultimo elemento de la tabla Libro y se extrae el idLibro
                int idLibro = await (from L in _context.Libros.OrderBy(x => x.IdLibro)
                                    select L.IdLibro).LastAsync();

                //Se crea el objeto de la tabla de rompimiento entre Libros y autores
                AutoresHasLibro tablaRompimiento = new AutoresHasLibro() { IdAutor = request.idAutor, IdLibro = idLibro };

                //Se insertan los datos y se guardan los cambios
                _context.AutoresHasLibros.Add(tablaRompimiento);
                await _context.SaveChangesAsync();

                //Se crea un objeto con el resultado de la insercion y el id del animal
                return new { resultado = true, idLibro = idLibro };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> ObtenerLibroPorId(int idLibro)
        {
            try
            {
                var datos = await (from L in _context.Libros.Where(x => x.IdLibro == idLibro)
                                   select new 
                                   {
                                       idLibro = L.IdLibro,
                                       nombreLibro = L.Titulo,
                                       sinopsis = L.Sinopsis,
                                       paginas = L.NPaginas,
                                   }).FirstOrDefaultAsync();

                return datos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> ActualizarLibro(ActualizarLibro request, int idLibroU)
        {
            try
            {
                // Se mapea el objeto request(AgregarLibro) a un objeto de la clase Libro para poder insertar los datos
                var EntidadDatosActualizados = _mapper.Map<Libro>(request);

                var EntidadActualizar = await _context.Libros.FirstOrDefaultAsync(x => x.IdLibro == idLibroU);

                if (EntidadActualizar != null)
                {
                    EntidadActualizar.Titulo = EntidadDatosActualizados.Titulo;
                    EntidadActualizar.NPaginas = EntidadDatosActualizados.NPaginas;
                    EntidadActualizar.Sinopsis = EntidadDatosActualizados.Sinopsis;

                    _context.Libros.Update(EntidadActualizar).Property(x => x.IdLibro).IsModified = false;
                    await _context.SaveChangesAsync();
                }

                //Se crea un objeto con el resultado de la insercion y el id del animal
                return new { resultado = "Datos actualizados correctamente!" };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
