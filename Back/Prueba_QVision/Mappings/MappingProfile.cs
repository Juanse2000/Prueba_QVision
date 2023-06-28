using AutoMapper;
using Prueba_QVision.Models;
using Prueba_QVision.Repositories.DTO;

namespace Prueba_QVision.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<infoBasica, Libro>();
            CreateMap<Libro, infoBasica>();

            CreateMap<ActualizarLibro, Libro>();
            CreateMap<Libro, ActualizarLibro>();
        }
    }
}
