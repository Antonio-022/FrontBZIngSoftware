using AutoMapper;
using PlantillaApiSAADS.DTOs;
using PlantillaApiSAADS.Models.RNDS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantillaApiSAADS.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<jugadorDTO, Jugador>().ReverseMap();
            CreateMap<EquipoDTO, Equipo>().ReverseMap();
            CreateMap<PerosnaWithJugador, Jugador>().ReverseMap();
            CreateMap<personaADD, Jugador>().ReverseMap();
            CreateMap<personaDTO, Persona>().ReverseMap();
        }
    }
}
