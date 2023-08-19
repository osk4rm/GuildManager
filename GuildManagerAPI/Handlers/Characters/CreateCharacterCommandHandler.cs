using GuildManager_Models;
using GuildManagerAPI.Commands.Characters;
using GuildManagerAPI.Services.Interfaces;
using MediatR;

namespace GuildManagerAPI.Handlers.Characters
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, ServiceResponse<int>>
    {
        private readonly ICharacterService _characterService;

        public CreateCharacterCommandHandler(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        public async Task<ServiceResponse<int>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            return await _characterService.CreateCharacter(request.CharacterDto);
        }
    }
}
