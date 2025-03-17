using Erp.Data.Entities.PurchasesModule;
using Entitis = Erp.Data.Entities.PurchasesModule;

namespace Erp.Core.Features.Supplier.Queries.Results
{
  public class GetSupplierByIdResult
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;
    public string? ContactInfo { get; set; }
    public string? Address { get; set; }
    public int AccountId { get; set; } // الحساب الفرعي (اختياري)

    public decimal Total { get; set; } = 0;

    public decimal PaidToDate { get; set; } = 0;

    public decimal BalanceDue { get; set; } = 0;

    // Navigation Properties
    public ICollection<Entitis.PurchaseInvoice> PurchaseInvoices { get; set; } = new List<Entitis.PurchaseInvoice>();

    public ICollection<SupplierPayment> supplierPayments { get; set; } = new List<SupplierPayment>();
    public ICollection<TransactionDto> transactionDtos { get; set; } = new List<TransactionDto>();


  }

  public class TransactionDto
  {
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Transaction { get; set; } = null!;
    public decimal Amount { get; set; } = 0;
    public decimal BalanceDue { get; set; } = 0;
  }

}
