using GuildManager_DataAccess.Enum;
using Microsoft.EntityFrameworkCore.Query;

namespace GuildManager_DataAccess.Entities.Raids
{
    public class RaidLocation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int RaidExpansionId { get; set; }
        public virtual RaidExpansion Expansion { get; set; } = new();
    }
}