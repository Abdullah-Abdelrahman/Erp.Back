namespace Name.Data.MetaData
{
  public static class Router
  {


    public const string Root = "/Api";
    // public const string Root = "";

    public const string Rule = Root + "/";

    public static class ProductAndServiceRouter
    {
      public const string prefix = Rule + "inventory/product-and-service/";

      public const string GetProductsServicesPaginated = prefix + "Paginated";


    }
    public static class ProductRouter
    {
      public const string prefix = Rule + "inventory/product/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";

    }

    public static class ServiceRouter
    {
      public const string prefix = Rule + "inventory/service/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";

    }
    public static class WarehouseRouter
    {
      public const string prefix = Rule + "Inventory/Warehouse/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }

    public static class SupplierRouter
    {
      public const string prefix = Rule + "Purchase/Supplier/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }
    public static class UserRouter
    {
      public const string prefix = Rule + "User/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

      public const string ChangePassword = prefix + "ChangePassword";

    }

    public static class AuthenticationRouter
    {
      public const string prefix = Rule + "Authentication/";

      public const string GetList = prefix + "List";

      public const string CanResetPassword = prefix + "CanResetPassword";

      public const string SignIn = prefix + "SignIn";

      public const string ConfirmEmail = prefix + "ConfirmEmail";

      public const string SendResetPasswordEmail = prefix + "SendResetPasswordEmail";


    }

    public static class AuthorizationRouter
    {
      public const string prefix = Rule + "Authorization/";

      public const string GetList = prefix + "Role/List";

      public const string GetById = prefix + "Role/{Id}";

      public const string Create = prefix + "Role/Create";

      public const string Edit = prefix + "Role/Edit";

      public const string Delete = prefix + "Role/Delete/{Id}";

      ////
      ///
      public const string ManageUserRoles = prefix + "ManageUserRolesQuery/{Id}";

      public const string UpdateUserRoles = prefix + "UpdateUserRoles";

      public const string ManageUserClaims = prefix + "ManageUserClaims/{Id}";

      public const string UpdateUserClaims = prefix + "UpdateUserClaims";

      public const string GetActiveModelsClamis = prefix + "get-active-models-clamis";

    }


    public static class CategoryRouter
    {
      public const string prefix = Rule + "inventory/category/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }

    public static class PriceListRouter
    {
      public const string prefix = Rule + "inventory/pricelist/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string AddItems = prefix + "add-items";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }


    public static class StockTakingRouter
    {
      public const string prefix = Rule + "inventory/stock-taking/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string AddItems = prefix + "add-items";

      public const string Edit = prefix + "edit";

      public const string Settlement = prefix + "settlement";

      public const string Delete = prefix + "delete/{Id}";


    }

    public static class ReceivingVoucherRouter
    {
      public const string prefix = Rule + "Inventory/ReceivingVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class DeliveryVoucherRouter
    {
      public const string prefix = Rule + "Inventory/DeliveryVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }


    public static class TransformVoucherRouter
    {
      public const string prefix = Rule + "Inventory/TransformVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class PurchaseInvoiceRouter
    {
      public const string prefix = Rule + "Purchase/PurchaseInvoice/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class PurchaseReturnRouter
    {
      public const string prefix = Rule + "Purchase/PurchaseReturn/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class DebitNoteRouter
    {
      public const string prefix = Rule + "Purchase/DebitNote/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }
    public static class AccountRouter
    {
      public const string prefix = Rule + "accounts/account/";

      public const string GetAccountTypeById = prefix + "getAccountTypeById/{Id}";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string GetMainAccountsList = prefix + "mainAccountsList";

      public const string GetPrimaryAccountsList = prefix + "primaryAccountsList";

      public const string GetSecondaryAccountsList = prefix + "secondaryAccountsList";



      public const string Edit = prefix + "edit";

      public const string GetSecondaryAccountById = prefix + "getSecondaryAccountById/{Id}";
      public const string GetPrimaryAccountById = prefix + "getPrimaryAccountById/{Id}";

      public const string Delete = prefix + "delete/{Id}";

    }

    public static class JournalEntryRouter
    {
      public const string prefix = Rule + "Accounts/JournalEntry/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class CostCenterRouter
    {
      public const string prefix = Rule + "Accounts/CostCenter/";

      public const string GetCostCenterTypeById = prefix + "GetCostCenterTypeById/{Id}";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string GetMainCostCentersList = prefix + "MainCostCentersList";

      public const string GetPrimaryCostCenterList = prefix + "primaryCostCenterList";

      public const string GetSecondaryCostCenterList = prefix + "secondaryCostCenterList";


      public const string Edit = prefix + "Edit";

      public const string GetSecondaryCostCenterById = prefix + "GetSecondaryCostCenterById/{Id}";
      public const string GetPrimaryCostCenterById = prefix + "GetPrimaryCostCenterById/{Id}";

      public const string Delete = prefix + "Delete/{Id}";

    }



    public static class CustomerRouter
    {
      public const string prefix = Rule + "Customers/Customer/";

      public const string GetCustomerTypeById = prefix + "GetCustomerTypeById/{Id}";

      public const string GetCustomerList = prefix + "list";


      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string GetIndividualCustomerById = prefix + "GetIndividualCustomerById/{Id}";
      public const string GetCommercialCustomerById = prefix + "GetCommercialCustomerById/{Id}";

      public const string Delete = prefix + "Delete/{Id}";

    }

    public static class CustomerClassificationRouter
    {
      public const string prefix = Rule + "Customers/CustomerClassification/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";


    }
    public static class ContactListRouter
    {
      public const string prefix = Rule + "Customers/ContactList/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }
    public static class PaymentRouter
    {
      public const string prefix = Rule + "Payment/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

    }

    public static class InvoiceRouter
    {
      public const string prefix = Rule + "Sales/Invoice/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class QuotationRouter
    {
      public const string prefix = Rule + "Sales/Quotation/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class CreditNoteRouter
    {
      public const string prefix = Rule + "Sales/CreditNote/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class RecurringInvoiceRouter
    {
      public const string prefix = Rule + "Sales/RecurringInvoice/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }


    public static class CustomerPaymentRouter
    {
      public const string prefix = Rule + "Sales/CustomerPayment/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }





    public static class BankAccountRouter
    {
      public const string prefix = Rule + "finance/bankAccount/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";



    }

    public static class TreasuryRouter
    {
      public const string prefix = Rule + "finance/treasury/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";



    }

    public static class ExpenseCategoryRouter
    {
      public const string prefix = Rule + "finance/expenseCategory/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }
    public static class ReceiptCategoryRouter
    {
      public const string prefix = Rule + "finance/receipt-category/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }

    public static class ExpenseRouter
    {
      public const string prefix = Rule + "finance/expense/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";



    }
    public static class ReceiptRouter
    {
      public const string prefix = Rule + "finance/receipt/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";



    }




    public static class DepartmentRouter
    {
      public const string prefix = Rule + "HumanResources/OrganizationalStructure/department/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }
    public static class EmploymentLevelRouter
    {
      public const string prefix = Rule + "HumanResources/OrganizationalStructure/employment-level/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }
    public static class EmploymentTypeRouter
    {
      public const string prefix = Rule + "HumanResources/OrganizationalStructure/employment-type/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }
    public static class JobTypeRouter
    {
      public const string prefix = Rule + "HumanResources/OrganizationalStructure/job-type/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }
    public static class EmployeeRouter
    {
      public const string prefix = Rule + "HumanResources/staff/employee/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";

    }

    public static class CompanyRouter
    {
      public const string prefix = Rule + "main/company/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";

    }
    public static class ModuleRouter
    {
      public const string prefix = Rule + "main/module/";

      public const string GetList = prefix + "list";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "create";

      public const string Edit = prefix + "edit";

      public const string Delete = prefix + "delete/{Id}";


    }

    public static class CompanyModuleRouter
    {
      public const string prefix = Rule + "main/module-manager/";

      public const string GetActiveModulesList = prefix + "list";

      public const string ActivateModule = prefix + "Activate/{Id}";

      public const string DeActivateModule = prefix + "DeActivate/{Id}";

    }
    public static class EmailRouter
    {
      public const string prefix = Rule + "Email/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Send = prefix + "Send";

    }
  }
}
