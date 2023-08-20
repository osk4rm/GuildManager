using FluentValidation.TestHelper;
using GuildManager_Models;
using GuildManagerAPI.Validation;

namespace GuildManager_IntegrationTests.Validators
{
    public class LoginValidatorTests
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

            return list.Select(q => new object[] {q});
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


        [Theory]
        [MemberData(nameof(GetSampleValidData))]
        public void Validate_ForCorrectModel_ReturnsSuccess(LoginDto loginDto)
        {
            //arrange
            var validator = new LoginValidator();

            //act
            var result = validator.TestValidate(loginDto);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(GetSampleInvalidData))]
        public void Validate_ForIncorrectModel_ReturnsError(LoginDto loginDto)
        {
            //arrange
            var validator = new LoginValidator();

            //act
            var result = validator.TestValidate(loginDto);

            //assert
            result.ShouldHaveAnyValidationError();
        }
    }
}
