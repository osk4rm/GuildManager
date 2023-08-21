using GuildManager_Models.Characters;

namespace GuildManager_IntegrationTests.Validators.SampleTestingData
{
    public class UpdateCharacterDtoValidatorTestingData
    {
        public static IEnumerable<object[]> GetSampleValidData()
        {
            var list = new List<UpdateCharacterDto>()
            {
                new UpdateCharacterDto
                {
                    Id = 1,
                    ItemLevel= 325,
                    MainSpecId = 2
                },
                new UpdateCharacterDto
                {
                    Id = 1,
                    ItemLevel = 332
                },
                new UpdateCharacterDto
                {
                    Id = 1,
                    MainSpecId = 3
                }
            };

            return list.Select(item => new object[] { item });
        }

        public static IEnumerable<object[]> GetSampleInvalidData()
        {
            var list = new List<UpdateCharacterDto>()
            {
                new UpdateCharacterDto
                {
                    Id = 2,
                    ItemLevel= 325,
                    MainSpecId = 2
                },
                new UpdateCharacterDto
                {
                    Id = 1,
                    ItemLevel = -8
                },
                new UpdateCharacterDto
                {
                    Id = 1,
                    MainSpecId = -5
                }
            };

            return list.Select(item => new object[] { item });
        }
    }
}
