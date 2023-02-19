using System;
using AutoMapper;
using DataAccess.Models;
using Models.Models;

namespace DataAccess.Models.Mapper
{
    public class PersonaProfileMap : Profile
    {
        public PersonaProfileMap()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
        }
    }
}
