using Erp.Service.Abstracts;
using Erp.Service.Abstracts.AccountsModule;
using Erp.Service.Abstracts.CommonUse;
using Erp.Service.Abstracts.CostCentersModule;
using Erp.Service.Abstracts.CustomersModule;
using Erp.Service.Abstracts.Finance;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Service.Abstracts.HumanResources.Staff;
using Erp.Service.Abstracts.InventoryModule;
using Erp.Service.Abstracts.MainModule;
using Erp.Service.Abstracts.SalesModule;
using Erp.Service.Implementations;
using Erp.Service.Implementations.AccountsModule;
using Erp.Service.Implementations.CommonUse;
using Erp.Service.Implementations.CostCentersModule;
using Erp.Service.Implementations.CustomersModule;
using Erp.Service.Implementations.Finance;
using Erp.Service.Implementations.HumanResources.OrganizationalStructure;
using Erp.Service.Implementations.HumanResources.Staff;
using Erp.Service.Implementations.InventoryModule;
using Erp.Service.Implementations.MainModule;
using Erp.Service.Implementations.SalesModule;
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

      services.AddTransient<IProductAndServiceBaseService, ProductAndServiceBaseService>();
      services.AddTransient<IProductService, ProductService>();
      services.AddTransient<ICategoryService, CategoryService>();
      services.AddTransient<IPriceListService, PriceListService>();
      services.AddTransient<IStockTakingService, StockTakingService>();
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

      services.AddTransient<IAccountService, AccountService>();


      services.AddTransient<IJournalEntryService, JournalEntryService>();
      services.AddTransient<IJournalEntryDetailService, JournalEntryDetailService>();



      services.AddTransient<ICostCenterService, CostCenterService>();





      services.AddTransient<ICustomerService, CustomerService>();
      services.AddTransient<ICustomerClassificationService, CustomerClassificationService>();

      services.AddTransient<IContactListService, ContactListService>();





      services.AddTransient<IInvoiceService, InvoiceService>();
      //services.AddTransient<IInvoiceItemService, InvoiceItemService>();
      services.AddTransient<IQuotationService, QuotationService>();
      //services.AddTransient<IQuotationItemService, QuotationItemService>();

      services.AddTransient<ICreditNoteService, CreditNoteService>();
      //services.AddTransient<ICreditNoteItemService, CreditNoteItemService>();



      services.AddTransient<IRecurringInvoiceService, RecurringInvoiceService>();
      services.AddTransient<IRecurringInvoiceItemService, RecurringInvoiceItemService>();




      services.AddTransient<IBankAccountService, BankAccountService>();

      services.AddTransient<ITreasuryService, TreasuryService>();


      services.AddTransient<IExpenseCategoryService, ExpenseCategoryService>();

      services.AddTransient<IReceiptCategoryService, ReceiptCategoryService>();

      services.AddTransient<IExpenseService, ExpenseService>();

      services.AddTransient<IReceiptService, ReceiptService>();




      services.AddTransient<IDepartmentService, DepartmentService>();
      services.AddTransient<IJobTypeService, JobTypeService>();
      services.AddTransient<IEmploymentLevelService, EmploymentLevelService>();
      services.AddTransient<IEmploymentTypeService, EmploymentTypeService>();



      services.AddTransient<IEmployeeService, EmployeeService>();


      services.AddTransient<IModuleService, ModuleService>();

      services.AddTransient<ICompanyService, CompanyService>();

      services.AddTransient<ICompanyModuleService, CompanyModuleService>();

      services.AddTransient<ISubscriptionService, SubscriptionService>();



      services.AddTransient<IPaymentService, PaymentService>();

      //to make it the same instance for the life time of a request

      return services;
    }
  }
}
