namespace Prueba_QVision.Repositories.DTO
{
    public class RespuestaGenerica
    {
        public object data { get; set; }
        public string errors { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string codigoRespuesta { get; set; }
    }
}
