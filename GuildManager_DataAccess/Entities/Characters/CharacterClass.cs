namespace GuildManager_DataAccess.Entities
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<ClassSpecialization> ClassSpecializations { get; set; } = new();
    }
}