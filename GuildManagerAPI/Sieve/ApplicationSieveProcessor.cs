using GuildManager_DataAccess.Entities.Raids;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace GuildManagerAPI.Sieve
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<RaidEvent>(r => r.Status)
                .CanFilter()
                .CanSort();

            mapper.Property<RaidEvent>(r => r.StartDate)
                .CanFilter()
                .CanSort();

            mapper.Property<RaidEvent>(r => r.RaidLocation)
                .CanFilter()
                .CanSort();

            mapper.Property<RaidEvent>(r => r.RaidDifficulty)
                .CanFilter()
                .CanSort();

            return mapper;
        }
    }
}
