using AutoMapper;
using DDD.Application.DTO;
using DDD.Domain.Commands;

namespace DDD.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<PlayerDTO, RegisterNewPlayerCommand>()
                .ConstructUsing(c => new RegisterNewPlayerCommand());
            CreateMap<PlayerDTO, UpdatePlayerCommand>()
                .ConstructUsing(c => new UpdatePlayerCommand());
        }
    }
}