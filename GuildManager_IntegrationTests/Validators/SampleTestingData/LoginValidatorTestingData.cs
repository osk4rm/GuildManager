using GuildManager_Models;

namespace GuildManager_IntegrationTests.Validators.SampleTestingData
{
    public class LoginValidatorTestingData
    {
        public static IEnumerable<object[]> GetSampleValidData()
        {
            var list = new List<LoginDto>()
            {
                new LoginDto()
                {
                Email = "test@test.com",
                Password = "test123"
                },
                new LoginDto()
                {
                Email = "test2@test.com",
                Password = "x"
                },
                new LoginDto()
                {
                Email = "dunno@test.com",
                Password = "xdqwefx"
                }
            };

            return list.Select(q => new object[] { q });
        }

        public static IEnumerable<object[]> GetSampleInvalidData()
        {
            var list = new List<LoginDto>()
            {
                new LoginDto()
                {
                Email = "",
                Password = ""
                },
                new LoginDto()
                {
                Email = "test2@test.com",
                Password = ""
                },
                new LoginDto()
                {
                Email = "@dunnotestcom",
                Password = "xdqwefx"
                },
                new LoginDto()
                {
                Email = "dunnotest.com",
                Password = "xdqwefx"
                }
            };

            return list.Select(q => new object[] { q });
        }
    }
}
