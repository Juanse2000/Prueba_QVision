using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Prueba_QVision.Repositories.DTO;
using Prueba_QVision.Repositories.Interface;

namespace Prueba_QVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private readonly ILibreria _libreria;
        public LibreriaController(ILibreria libreria) 
        {
            _libreria = libreria;
        }

        [HttpGet("/api/Libreria/ObtenerLibros")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerLibros()
        {
            try
            {
                var datos = await _libreria.ObtenerLibros();

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpGet("/api/Libreria/ObtenerDetalle/{idLibro}")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerDetalle(int idLibro)
        {
            try
            {
                var datos = await _libreria.ObtenerDetalle(idLibro);

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpGet("/api/Libreria/ObtenerListaEditoriales")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerListaEditoriales()
        {
            try
            {
                var datos = await _libreria.ObtenerListaEditoriales();

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpGet("/api/Libreria/ObtenerListaAutores")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerListaAutores()
        {
            try
            {
                var datos = await _libreria.ObtenerListaAutores();

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpPost("/api/Libreria/AgregarLibro")]
        public async Task<ActionResult<RespuestaGenerica>> AgregarLibro(AgregarLibro request)
        {
            try
            {
                var datos = await _libreria.AgregarLibro(request);

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpGet("/api/Libreria/ObtenerLibroPorId/{idLibro}")]
        public async Task<ActionResult<RespuestaGenerica>> ObtenerLibroPorId(int idLibro)
        {
            try
            {
                var datos = await _libreria.ObtenerLibroPorId(idLibro);

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }

        [HttpPut("/api/Libreria/ActualizarLibro/{idLibro}")]
        public async Task<ActionResult<RespuestaGenerica>> ActualizarLibro(ActualizarLibro request, int idLibro)
        {
            try
            {
                var datos = await _libreria.ActualizarLibro(request, idLibro);

                return new RespuestaGenerica
                {
                    data = datos,
                    status = 200,
                    title = "OK ",
                    codigoRespuesta = "01"
                };

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaGenerica
                {
                    errors = ex.Message,
                    status = 400,
                    title = "Error",
                    codigoRespuesta = "01"
                });
            }
        }
    }
}
