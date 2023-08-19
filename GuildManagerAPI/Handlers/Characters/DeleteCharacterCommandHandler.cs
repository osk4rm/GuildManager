using GuildManager_Models;
using GuildManagerAPI.Commands.Characters;
using GuildManagerAPI.Services.Interfaces;
using MediatR;

namespace GuildManagerAPI.Handlers.Characters
{
    public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand, ServiceResponse<bool>>
    {
        private readonly ICharacterService _characterService;

        public DeleteCharacterCommandHandler(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        public async Task<ServiceResponse<bool>> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            return await _characterService.DeleteCharacter(request.Id);
        }
    }
}
