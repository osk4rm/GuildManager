using FluentValidation.TestHelper;
using GuildManager_DataAccess;
using GuildManager_IntegrationTests.Validators.SampleTestingData;
using GuildManager_Models.Characters;
using GuildManagerAPI.Validation.CharactersOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies.Internal;

namespace GuildManager_IntegrationTests.Validators
{
    public class CreateCharacterDtoValidatorTests : ValidatorsTestsBase
    {
        public CreateCharacterDtoValidatorTests() : base()
        {
        }

        [Theory]
        [MemberData(nameof(CreateCharacterDtoValidatorTestingData.GetSampleValidData), MemberType = typeof(CreateCharacterDtoValidatorTestingData))]
        public async Task Validate_ForValidModel_ReturnsSuccess(CreateCharacterDto dto)
        {
            CreateDbContextAndSeed();
            
            var validator = new CreateCharacterDtoValidator(_dbContext);

            //act
            var result = validator.TestValidate(dto);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [MemberData(nameof(CreateCharacterDtoValidatorTestingData.GetSampleInvalidData), MemberType = typeof(CreateCharacterDtoValidatorTestingData))]
        public async Task Validate_ForInvalidModel_ReturnsFailure(CreateCharacterDto dto)
        {
            //arrange
            CreateDbContextAndSeed();

            var model = new CreateCharacterDto
            {
                ClassId = 1,
                ClassSpecializationId = 7,
                ItemLevel = 320,
                Name = "Test"
            };

            var validator = new CreateCharacterDtoValidator(_dbContext);

            //act
            var result = validator.TestValidate(dto);

            //assert
            result.ShouldHaveAnyValidationError();
            
        }

        
    }
}
