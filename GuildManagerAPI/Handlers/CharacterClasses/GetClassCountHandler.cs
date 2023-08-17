using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using GuildManagerAPI.Queries.CharacterClasses;
using MediatR;
using GuildManagerAPI.Services.Interfaces;

namespace GuildManagerAPI.Handlers.CharacterClasses
{
    public class GetClassCountHandler : IRequestHandler<GetClassCountQuery, ServiceResponse<List<ClassCountDto>>>
    {
        private readonly IClassesService _classesService;

        public GetClassCountHandler(IClassesService classesService)
        {
            _classesService = classesService;
        }
        public async Task<ServiceResponse<List<ClassCountDto>>> Handle(GetClassCountQuery request, CancellationToken cancellationToken)
        {
            var response = await _classesService.GetClassCount();

            return response;
        }
    }
}
