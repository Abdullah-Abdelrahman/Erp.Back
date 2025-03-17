using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Erp.Data.Entities.PurchasesModule
{
  public class SupplierPayment : Payment
  {
    public int SupplierId { get; set; }
    [JsonIgnore]
    [ForeignKey("SupplierId")]
    public Supplier Supplier { get; set; } = null!;

    public int? PurchaseInvoiceId { get; set; }
    [ForeignKey(nameof(PurchaseInvoiceId))]
    public PurchaseInvoice? PurchaseInvoice { get; set; } = null!;


    public int? PurchaseReturnId { get; set; }
    [ForeignKey(nameof(PurchaseReturnId))]
    public PurchaseReturn? PurchaseReturn { get; set; } = null!;




    public string SupplierName { get; set; } = string.Empty;

    public string? City { get; set; }
    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Telephone { get; set; }


  }
}
