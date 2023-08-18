using GuildManager_Models.Characters;
using GuildManager_Models;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuildManager_Models.CharacterClassesAndSpecs;
using MediatR;
using GuildManagerAPI.Queries;
using GuildManagerAPI.Queries.CharacterClasses;

namespace GuildManagerAPI.Requests.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ClassesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<RoleCountDto>>>> GetRoleCount()
        {
            var query = new GetRoleCountQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<ClassCountDto>>>> GetClassCount()
        {
            var query = new GetClassCountQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<CharacterClassDto>>>> GetAll()
        {
            var query = new GetAllCharacterClassesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
