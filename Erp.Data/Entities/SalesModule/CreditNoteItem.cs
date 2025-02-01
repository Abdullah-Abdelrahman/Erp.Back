using Erp.Data.Dto.CreditNote;
using Erp.Data.Entities.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.SalesModule
{
  public class CreditNoteItem
  {

    [Key]
    public int CreditNoteItemID { get; set; }

    public int CreditNoteID { get; set; }

    [ForeignKey("CreditNoteID")]
    public CreditNote creditNote { get; set; }

    public int productID { get; set; }

    [ForeignKey("productID")]
    public Product product { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    [Required]
    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; } = 0;
    public decimal Tax { get; set; } = 0;
    public decimal Total => (UnitPrice * Quantity) - Discount + Tax;

    public CreditNoteItem(CreditNoteItemDT0 itemDT0, int CreditNoteID)
    {
      CreditNoteID = CreditNoteID;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;


    }

    public CreditNoteItem(CreditNoteItemUpdateDT0 itemDT0)
    {
      CreditNoteItemID = itemDT0.CreditNoteItemId;
      CreditNoteID = itemDT0.CreditNoteId;
      productID = itemDT0.ProductId;
      Description = itemDT0.Description;
      Quantity = itemDT0.Quantity;
      UnitPrice = itemDT0.UnitPrice;
      Discount = itemDT0.discount;
      Tax = itemDT0.Tax;
    }
  }
}
