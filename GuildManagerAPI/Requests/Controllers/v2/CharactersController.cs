using GuildManager_Models;
using GuildManager_Models.Characters;
using GuildManagerAPI.Services.Interfaces;
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

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<int>>> Create(CreateCharacterDto dto)
        {
            var response = await _characterService.CreateCharacter(dto);

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> GetUserCharacters()
        {
            var response = await _characterService.GetUserCharacters();

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
            var response = await _characterService.DeleteCharacter(id);

            return Ok(response);
        }
    }
}
