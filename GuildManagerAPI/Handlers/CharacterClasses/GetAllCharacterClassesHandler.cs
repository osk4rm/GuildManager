using GuildManager_Models.CharacterClassesAndSpecs;
using GuildManager_Models;
using MediatR;
using GuildManagerAPI.Services.Interfaces;
using GuildManagerAPI.Queries.CharacterClasses;

namespace GuildManagerAPI.Handlers.CharacterClasses
{
    public class GetAllCharacterClassesHandler : IRequestHandler<GetAllCharacterClassesQuery, ServiceResponse<List<CharacterClassDto>>>
    {
        private readonly IClassesService _classesService;

        public GetAllCharacterClassesHandler(IClassesService classesService)
        {
            _classesService = classesService;
        }
        public async Task<ServiceResponse<List<CharacterClassDto>>> Handle(GetAllCharacterClassesQuery request, CancellationToken cancellationToken)
        {
            var response = await _classesService.GetClasses();

            return response;
        }
    }
}
