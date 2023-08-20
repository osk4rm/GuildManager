using GuildManager_Models.Characters;

namespace GuildManager_IntegrationTests.Validators.SampleTestingData
{
    public class CreateCharacterDtoValidatorTestingData
    {
        public static IEnumerable<object[]> GetSampleValidData()
        {
            var list = new List<CreateCharacterDto>
            {
                new CreateCharacterDto
                {
                    ClassSpecializationId = 1,
                    ClassId = 1,
                    ItemLevel = 320,
                    Name = "Iamvalid"
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = 2,
                    ClassId = 4,
                    ItemLevel = 333,
                    Name = "Iamvalid"
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = 3,
                    ClassId = 9,
                    ItemLevel = 333,
                    Name = "Iamvalid"
                },
            };

            return list.Select(l => new object[] { l });
        }

        public static IEnumerable<object[]> GetSampleInvalidData()
        {
            var list = new List<CreateCharacterDto>
            {
                new CreateCharacterDto
                {
                    ClassId = 1,
                    ItemLevel = 320,
                    Name = "Iaminvalid"
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = 2,
                    ItemLevel = 333,
                    Name = "Iamvalid"
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = 3,
                    ClassId = 9,
                    ItemLevel = 333,
                    Name = ""
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = 3,
                    ClassId = 76,
                    ItemLevel = 333,
                    Name = "Iaminvalid"
                },
                new CreateCharacterDto
                {
                    ClassSpecializationId = -1,
                    ClassId = 9,
                    ItemLevel = 333,
                    Name = "Iaminvalid"
                },
            };

            return list.Select(l => new object[] { l });
        }
    }
}
