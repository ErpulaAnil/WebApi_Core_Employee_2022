namespace Ef_Core_Relationships_Tutorial
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = string.Empty;
        public User User { get; set; } 
        public int UserId { get; set; } 
    }
}
