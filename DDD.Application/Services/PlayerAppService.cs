using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Domain.Commands;
using DDD.Domain.Interfaces;
using DDD.Infra.CrossCutting.Bus.Core.Mediator;
using DDD.Infra.CrossCutting.Bus.Core.Messages;

namespace DDD.Application.Services
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMediatorHandler _mediator;

        public PlayerAppService(IMapper mapper, IPlayerRepository playerRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
            _mediator = mediator;
        }
        
        public async Task<IEnumerable<PlayerDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<PlayerDTO>>(await _playerRepository.GetAll());
        }

        public async Task<PlayerDTO> GetById(Guid id)
        {
            return _mapper.Map<PlayerDTO>(await _playerRepository.GetById(id));
        }

        public async Task<CommandResult> Register(PlayerDTO playerDto)
        {
            var registerCommand = _mapper.Map<RegisterNewPlayerCommand>(playerDto);
            return await _mediator.EnviarComando(registerCommand);
        }

        public async Task<CommandResult> Update(PlayerDTO playerDto)
        {
            var updateCommand = _mapper.Map<UpdatePlayerCommand>(playerDto);
            return await _mediator.EnviarComando(updateCommand);
        }

        public async Task<CommandResult> Remove(Guid id)
        {
            var removeCommand = new RemovePlayerCommand();
            return await _mediator.EnviarComando(removeCommand);
        }
    }
}