using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using GuildManagerAPI.Queries.CharacterClasses;
using MediatR;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Handlers.CharacterClasses
{
    public class GetRoleCountHandler : IRequestHandler<GetRoleCountQuery, ServiceResponse<List<RoleCountDto>>>
    {
        private readonly IClassesService _classesService;

        public GetRoleCountHandler(IClassesService classesService)
        {
            _classesService = classesService;
        }
        public async Task<ServiceResponse<List<RoleCountDto>>> Handle(GetRoleCountQuery request, CancellationToken cancellationToken)
        {
           return await _classesService.GetRoleCount();
        }
    }
}
