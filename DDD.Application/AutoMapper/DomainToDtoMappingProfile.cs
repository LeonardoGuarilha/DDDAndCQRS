using AutoMapper;
using DDD.Application.DTO;
using DDD.Domain.Models;

namespace DDD.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Player, PlayerDTO>();
        }
    }
}