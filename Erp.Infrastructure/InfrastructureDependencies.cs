using Erp.Data.Entities;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.CustomersModule;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.CommonUse;
using Erp.Infrastructure.Abstracts.CostCentersModule;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Erp.Infrastructure.Abstracts.HumanResources.Staff;
using Erp.Infrastructure.Abstracts.InventoryModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Infrastructure.Repositories;
using Erp.Infrastructure.Repositories.AccountsModule;
using Erp.Infrastructure.Repositories.CommonUse;
using Erp.Infrastructure.Repositories.CostCentersModule;
using Erp.Infrastructure.Repositories.CustomersModule;
using Erp.Infrastructure.Repositories.Finance;
using Erp.Infrastructure.Repositories.HumanResources.OrganizationalStructure;
using Erp.Infrastructure.Repositories.HumanResources.Staff;
using Erp.Infrastructure.Repositories.InventoryModule;
using Erp.Infrastructure.Repositories.MainModule;
using Erp.Infrastructure.Repositories.SalesModule;
using Erp.Service.Abstracts.MainModule;
using Erp.Service.Implementations.MainModule;
using Microsoft.Extensions.DependencyInjection;
using Name.Infrastructure.Bases;

namespace Name.Infrastructure
{
  public static class InfrastructureDependencies
  {

    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {


      services.AddTransient<IProductAndServiceRepository<ProductAndServiceBase>, ProductAndServiceRepository<ProductAndServiceBase>>();


      services.AddTransient<IProductAndServiceRepository<Service>, ProductAndServiceRepository<Service>>();

      services.AddTransient<IProductRepository, ProductRepository>();
      services.AddTransient<ICategoryRepository, CategoryRepository>();
      services.AddTransient<IPriceListRepository, PriceListRepository>();
      services.AddTransient<IStockTakingRepository, StockTakingRepository>();
      services.AddTransient<IStockTransactionRepository, StockTransactionRepository>();
      services.AddTransient<IDeliveryVoucherRepository, DeliveryVoucherRepository>();
      services.AddTransient<IReceivingVoucherRepository, ReceivingVoucherRepository>();
      services.AddTransient<IWarehouseRepository, WarehouseRepository>();
      services.AddTransient<IReceivingVoucherItemRepository, ReceivingVoucherItemRepository>();
      services.AddTransient<IDeliveryVoucherItemRepository, DeliveryVoucherItemRepository>();
      services.AddTransient<ITransformVoucherRepository, TransformVoucherRepository>();
      services.AddTransient<ITransformVoucherItemRepository, TransformVoucherItemRepository>();
      services.AddTransient<IVoucherStatusRepository, VoucherStatusRepository>();



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




      services.AddTransient<ICustomerRepository<Customer>, CustomerRepository<Customer>>();
      services.AddTransient<ICustomerRepository<CommercialCustomer>, CustomerRepository<CommercialCustomer>>();
      services.AddTransient<ICustomerRepository<IndividualCustomer>, CustomerRepository<IndividualCustomer>>();



      services.AddTransient<ICustomerClassificationRepository, CustomerClassificationRepository>();

      services.AddTransient<IContactListRepository, ContactListRepository>();



      services.AddTransient<IInvoiceRepository, InvoiceRepository>();
      services.AddTransient<IInvoiceItemRepository, InvoiceItemRepository>();

      services.AddTransient<IQuotationRepository, QuotationRepository>();
      services.AddTransient<IQuotationItemRepository, QuotationItemRepository>();


      services.AddTransient<ICreditNoteRepository, CreditNoteRepository>();
      services.AddTransient<ICreditNoteItemRepository, CreditNoteItemRepository>();



      services.AddTransient<IRecurringInvoiceRepository, RecurringInvoiceRepository>();
      services.AddTransient<IRecurringInvoiceItemRepository, RecurringInvoiceItemRepository>();






      services.AddTransient<IBankAccountRepository, BankAccountRepository>();

      services.AddTransient<ITreasuryRepository, TreasuryRepository>();

      services.AddTransient<IExpenseCategoryRepository, ExpenseCategoryRepository>();

      services.AddTransient<IReceiptCategoryRepository, ReceiptCategoryRepository>();

      services.AddTransient<IExpenseRepository, ExpenseRepository>();

      services.AddTransient<IReceiptRepository, ReceiptRepository>();


      services.AddTransient<IMultiAccExpenseItemRepository, MultiAccExpenseItemRepository>();
      services.AddTransient<IMultiAccReceiptItemRepository, MultiAccReceiptItemRepository>();




      services.AddTransient<IEmployeeRepository, EmployeeRepository>();

      services.AddTransient<IDepartmentRepository, DepartmentRepository>();
      services.AddTransient<IJobTypeRepository, JobTypeRepository>();
      services.AddTransient<IEmploymentLevelRepository, EmploymentLevelRepository>();
      services.AddTransient<IEmploymentTypeRepository, EmploymentTypeRepository>();






      services.AddTransient<ICompanyRepository, CompanyRepository>();

      services.AddTransient<IApplicationRoleRepository, ApplicationRoleRepository>();

      services.AddTransient<IModuleRepository, ModuleRepository>();
      services.AddTransient<ICompanyModuleRepository, CompanyModuleRepository>();
      services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
      services.AddTransient<ICompanySubscriptionRepository, CompanySubscriptionRepository>();


      services.AddTransient<IPaymentRepository<Payment>, PaymentRepository<Payment>>();
      services.AddTransient<IPaymentRepository<SupplierPayment>, PaymentRepository<SupplierPayment>>();
      services.AddTransient<IPaymentRepository<ClientPayment>, PaymentRepository<ClientPayment>>();


      services.AddScoped<ITenantRepository, TenantRepository>();
      services.AddScoped<ITenantService, TenantService>();
      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      return services;
    }
  }
}
