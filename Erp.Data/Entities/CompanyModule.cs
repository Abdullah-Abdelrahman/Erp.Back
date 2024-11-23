namespace Name.Data.Entities
{
    public class CompanyModule
    {
        public int CompanyModuleID { get; set; }

        public int CompanyID { get; set; }

        public int ModuleID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public Company Company { get; set; } = null!;

        public Module Module { get; set; } = null!;
    }

}
