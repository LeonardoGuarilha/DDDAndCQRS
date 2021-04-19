using System.Threading.Tasks;
using DDD.Application.DTO;
using DDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.API.Controllers
{
    public class PlayerController : BaseController
    {

        private readonly IPlayerAppService _playerAppService;

        public PlayerController(IPlayerAppService playerAppService)
        {
            _playerAppService = playerAppService;
        }

        [HttpPost("v1/player")]
        public async Task<IActionResult> Post([FromBody] PlayerDTO playerDto)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _playerAppService.Register(playerDto));
        }

    }
}