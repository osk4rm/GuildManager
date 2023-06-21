using GuildManager_Models.Characters;
using GuildManager_Models;
using GuildManagerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuildManager_Models.CharacterClassesAndSpecs;

namespace GuildManagerAPI.Requests.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesService _classesService;

        public ClassesController(IClassesService classesService)
        {
            _classesService = classesService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<RoleCountDto>>>> GetRoleCount()
        {
            var response = await _classesService.GetRoleCount();

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<ClassCountDto>>>> GetClassCount()
        {
            var response = await _classesService.GetClassCount();

            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ServiceResponse<List<CharacterClassDto>>>> GetAll()
        {
            var response = await _classesService.GetClasses();

            return Ok(response);
        }
    }
}
