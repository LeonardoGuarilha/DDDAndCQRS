using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Application.DTO;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using FluentValidation.Results;

namespace DDD.Application.Interfaces
{
    public interface IPlayerAppService
    {
        Task<IEnumerable<PlayerDTO>> GetAll();
        Task<PlayerDTO> GetById(Guid id);
        
        Task<CommandResult> Register(PlayerDTO playerDto);
        Task<CommandResult> Update(PlayerDTO playerDto);
        Task<CommandResult> Remove(Guid id);
    }
}