using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Name.Data.Entities
{
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string WarehouseName { get; set; }

        public string Location { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
