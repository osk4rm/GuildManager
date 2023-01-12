namespace GuildManager_DataAccess.Entities
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public virtual List<ClassSpecialization> ClassSpecializations { get; set; }
        public virtual List<Character> Characters { get; set; } = new();
    }
}