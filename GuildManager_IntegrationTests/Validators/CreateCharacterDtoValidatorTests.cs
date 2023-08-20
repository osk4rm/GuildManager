﻿using FluentValidation.TestHelper;
using GuildManager_DataAccess;
using GuildManager_Models.Characters;
using GuildManagerAPI.Validation.CharactersOperations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies.Internal;

namespace GuildManager_IntegrationTests.Validators
{
    public class CreateCharacterDtoValidatorTests
    {
        private GuildManagerDbContext _dbContext;

        public CreateCharacterDtoValidatorTests()
        {
            var builder = new DbContextOptionsBuilder<GuildManagerDbContext>();
            builder.UseInMemoryDatabase("TestDB");
            _dbContext = new GuildManagerDbContext(builder.Options);
            Seed();

        }
        [Fact]
        public void Validate_ForValidModel_ReturnsSuccess()
        {
            //arrange
            var model = new CreateCharacterDto
            {
                ClassId = 1,
                ClassSpecializationId = 1,
                ItemLevel = 320,
                Name = "Test"
            };
            

            var validator = new CreateCharacterDtoValidator(_dbContext);

            //act
            var result = validator.TestValidate(model);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ForInvalidModel_ReturnsSuccess()
        {
            //arrange
            var model = new CreateCharacterDto
            {
                ClassId = 1,
                ClassSpecializationId = 7,
                ItemLevel = 320,
                Name = "Test"
            };


            var validator = new CreateCharacterDtoValidator(_dbContext);

            //act
            var result = validator.TestValidate(model);

            //assert
            result.ShouldHaveAnyValidationError();
        }

        public void Seed()
        {
            Seeder seeder = new Seeder(_dbContext);
            seeder.Seed();
        }
    }
}