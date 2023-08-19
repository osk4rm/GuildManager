using GuildManager_Models;
using GuildManager_Models.Characters;
using MediatR;

namespace GuildManagerAPI.Commands.Characters
{
    public class CreateCharacterCommand : IRequest<ServiceResponse<int>>
    {
        public CreateCharacterDto CharacterDto { get; set; }

        public CreateCharacterCommand(CreateCharacterDto dto)
        {
            CharacterDto = dto;
        }
    }
}
