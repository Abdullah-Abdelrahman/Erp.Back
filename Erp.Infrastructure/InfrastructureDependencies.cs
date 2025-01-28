using Erp.Data.Entities.AccountsModule;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.CostCentersModule;
using Erp.Infrastructure.Repositories;
using Erp.Infrastructure.Repositories.AccountsModule;
using Erp.Infrastructure.Repositories.CostCentersModule;
using Microsoft.Extensions.DependencyInjection;
using Name.Infrastructure.Bases;

namespace Name.Infrastructure
{
  public static class InfrastructureDependencies
  {

    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {



      services.AddTransient<IProductRepository, ProductRepository>();
      services.AddTransient<ICategoryRepository, CategoryRepository>();
      services.AddTransient<IStockTransactionRepository, StockTransactionRepository>();
      services.AddTransient<IDeliveryVoucherRepository, DeliveryVoucherRepository>();
      services.AddTransient<IReceivingVoucherRepository, ReceivingVoucherRepository>();
      services.AddTransient<IWarehouseRepository, WarehouseRepository>();
      services.AddTransient<IReceivingVoucherItemRepository, ReceivingVoucherItemRepository>();
      services.AddTransient<IDeliveryVoucherItemRepository, DeliveryVoucherItemRepository>();
      services.AddTransient<ITransformVoucherRepository, TransformVoucherRepository>();
      services.AddTransient<ITransformVoucherItemRepository, TransformVoucherItemRepository>();


      services.AddTransient<ISupplierRepository, SupplierRepository>();

      services.AddTransient<IPurchaseInvoiceRepository, PurchaseInvoiceRepository>();
      services.AddTransient<IPurchaseInvoiceItemRepository, PurchaseInvoiceItemRepository>();

      services.AddTransient<IPurchaseReturnRepository, PurchaseReturnRepository>();

      services.AddTransient<IPurchaseReturnItemRepository, PurchaseReturnItemRepository>();


      services.AddTransient<IDebitNoteRepository, DebitNoteRepository>();

      services.AddTransient<IDebitNoteItemRepository, DebitNoteItemRepository>();

      services.AddTransient<IAccountRepository<Account>, AccountRepository<Account>>();
      services.AddTransient<IAccountRepository<PrimaryAccount>, AccountRepository<PrimaryAccount>>();
      services.AddTransient<IAccountRepository<SecondaryAccount>, AccountRepository<SecondaryAccount>>();


      services.AddTransient<IJournalEntryRepository, JournalEntryRepository>();

      services.AddTransient<IJournalEntryDetailRepository, JournalEntryDetailRepository>();



      services.AddTransient<ICostCenterRepository<CostCenter>, CostCenterRepository<CostCenter>>();
      services.AddTransient<ICostCenterRepository<PrimaryCostCenter>, CostCenterRepository<PrimaryCostCenter>>();
      services.AddTransient<ICostCenterRepository<SecondaryCostCenter>, CostCenterRepository<SecondaryCostCenter>>();






      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      return services;
    }
  }
}
