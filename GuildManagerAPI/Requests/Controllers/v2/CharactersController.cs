using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Commands.Characters;
using GuildManagerAPI.Queries.Characters;
using GuildManagerAPI.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerAPI.Requests.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMediator _mediator;

        public CharactersController(ICharacterService characterService, IMediator mediator)
        {
            _characterService = characterService;
            _mediator = mediator;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<int>>> Create(CreateCharacterDto dto)
        {
            var response = await _mediator.Send(new CreateCharacterCommand(dto));

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> GetUserCharacters()
        {
            var response = await _mediator.Send(new GetUserCharactersQuery());

            return Ok(response);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<CharacterDto>>> Update(UpdateCharacterDto dto)
        {
            var response = await _characterService.UpdateCharacter(dto);

            return Ok(response);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCharacterCommand(id));

            return Ok(response);
        }
    }
}
