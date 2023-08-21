using FluentValidation.TestHelper;
using GuildManager_DataAccess.Entities;
using GuildManager_IntegrationTests.Validators.SampleTestingData;
using GuildManager_Models.Characters;
using GuildManagerAPI.Validation.CharactersOperations;
using Microsoft.EntityFrameworkCore;

namespace GuildManager_IntegrationTests.Validators
{
    public class UpdateCharacterDtoValidatorTests : ValidatorsTestsBase
    {
        private UpdateCharacterDtoValidator _sut;
        public UpdateCharacterDtoValidatorTests() : base()
        {
            
        }

        [Theory]
        [MemberData(nameof(UpdateCharacterDtoValidatorTestingData.GetSampleValidData), MemberType = typeof(UpdateCharacterDtoValidatorTestingData))]
        public async Task Validator_ForValidInput_ReturnsSuccess(UpdateCharacterDto dto)
        {
            //arrange
            CreateDbContextAndSeed();
            CreateDummyCharacter();


            //act
            var validationResult = _sut.TestValidate(dto);

            //assert
            validationResult.ShouldNotHaveAnyValidationErrors();

            
        }

        [Theory]
        [MemberData(nameof(UpdateCharacterDtoValidatorTestingData.GetSampleInvalidData), MemberType = typeof(UpdateCharacterDtoValidatorTestingData))]
        public async Task Validator_ForInvalidInput_ReturnsFailure(UpdateCharacterDto dto)
        {
            //arrange
            CreateDbContextAndSeed();
            CreateDummyCharacter();

            //act
            var validationResult = _sut.TestValidate(dto);

            //assert
            validationResult.ShouldHaveAnyValidationError();

            
        }

        private void CreateDummyCharacter()
        {
            //let's add dummy character to update
            Character character = new Character
            {
                Id = 1,
                MainSpec = _dbContext.ClassSpecializations.FirstOrDefault(s => s.CharacterClassId == 1),
                Class = _dbContext.CharacterClasses.FirstOrDefault(c => c.Name.ToLower() == "death knight"),
                ItemLevel = 320,
                Name = "TestDK",
                UserId = 1
            };

            if (!_dbContext.Characters.Any(c => c.Id == character.Id))
            {
                _dbContext.Characters.Add(character);
                _dbContext.SaveChanges();
            }
            _sut = new(_dbContext);
        }
    }
}
