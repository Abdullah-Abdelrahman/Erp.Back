using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Name.Data.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        [Required]
        public decimal Total { get; set; }
    }
}
