using GuildManager_Models;
using MediatR;

namespace GuildManagerAPI.Commands.Characters
{
    public class DeleteCharacterCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; }

        public DeleteCharacterCommand(int id)
        {
            Id = id;
        }
    }
}
