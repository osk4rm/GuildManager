﻿using GuildManager_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.CharacterClassesAndSpecs
{
    public class CharacterClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<ClassSpecDto> ClassSpecializations { get; set; } = new();
    }
}
