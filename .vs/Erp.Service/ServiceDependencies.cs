using Erp.Service.Abstracts;
using Erp.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Name.Service.Abstracts;
using Name.Service.Implementations;

namespace Name.Service
{
  public static class ServiceDependencies
  {

    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {

      services.AddTransient<IAuthenticationService, AuthenticationService>();
      services.AddTransient<IAuthorizationService, AuthorizationService>();


      services.AddTransient<IFileService, FileService>();
      services.AddTransient<IEmailService, EmailService>();
      services.AddTransient<IUserBaseService, UserBaseService>();

      services.AddTransient<IProductService, ProductService>();
      services.AddTransient<ICategoryService, CategoryService>();
      services.AddTransient<IStockTransactionService, StockTransactionService>();
      services.AddTransient<IDeliveryVoucherService, DeliveryVoucherService>();
      services.AddTransient<IReceivingVoucherService, ReceivingVoucherService>();
      services.AddTransient<IWarehouseService, WarehouseService>();
      services.AddTransient<IReceivingVoucherItemService, ReceivingVoucherItemService>();
      services.AddTransient<IDeliveryVoucherItemService, DeliveryVoucherItemService>();
      services.AddTransient<ITransformVoucherService, TransformVoucherService>();
      services.AddTransient<ITransformVoucherItemService, TransformVoucherItemService>();

      services.AddTransient<ISupplierService, SupplierService>();



      services.AddTransient<IPurchaseInvoiceService, PurchaseInvoiceService>();
      services.AddTransient<IPurchaseInvoiceItemService, PurchaseInvoiceItemService>();

      services.AddTransient<IPurchaseReturnService, PurchaseReturnService>();
      services.AddTransient<IPurchaseReturnItemService, PurchaseReturnItemService>();



      services.AddTransient<IDebitNoteService, DebitNoteService>();
      services.AddTransient<IDebitNoteItemService, DebitNoteItemService>();


      return services;
    }
  }
}
