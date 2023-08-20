using FluentValidation.TestHelper;
using GuildManager_IntegrationTests.Validators.SampleTestingData;
using GuildManager_Models;
using GuildManagerAPI.Validation;

namespace GuildManager_IntegrationTests.Validators
{
    public class LoginValidatorTests
    {
        [Theory]
        [MemberData(nameof(LoginValidatorTestingData.GetSampleValidData), MemberType = typeof(LoginValidatorTestingData))]
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
        [MemberData(nameof(LoginValidatorTestingData.GetSampleInvalidData), MemberType = typeof(LoginValidatorTestingData))]
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
