namespace Name.Data.Entities
{
    public class Module
    {
        public int ModuleID { get; set; }

        public string ModuleName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

}
