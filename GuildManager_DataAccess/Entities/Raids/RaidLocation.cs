using GuildManager_DataAccess.Enum;
using Microsoft.EntityFrameworkCore.Query;

namespace GuildManager_DataAccess.Entities.Raids
{
    public class RaidLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public RaidExpansion? Expansion { get; set; }
        public int? ExpansionId { get; set; }
        public RaidDifficulty RaidDifficulty { get; set; }
    }
}