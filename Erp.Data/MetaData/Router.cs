namespace Name.Data.MetaData
{
  public static class Router
  {

    public const string Root = "/Api";
    public const string Rule = Root + "/";


    public static class ProductRouter
    {
      public const string prefix = Rule + "Product/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }
    public static class WarehouseRouter
    {
      public const string prefix = Rule + "Warehouse/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }

    public static class SupplierRouter
    {
      public const string prefix = Rule + "Supplier/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";

    }
    public static class UserRouter
    {
      public const string prefix = Rule + "UserApp/";

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
    }


    public static class CategoryRouter
    {
      public const string prefix = Rule + "Category/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";


    }




    public static class ReceivingVoucherRouter
    {
      public const string prefix = Rule + "ReceivingVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class DeliveryVoucherRouter
    {
      public const string prefix = Rule + "DeliveryVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }


    public static class TransformVoucherRouter
    {
      public const string prefix = Rule + "TransformVoucher/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class PurchaseInvoiceRouter
    {
      public const string prefix = Rule + "PurchaseInvoice/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class PurchaseReturnRouter
    {
      public const string prefix = Rule + "PurchaseReturn/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class DebitNoteRouter
    {
      public const string prefix = Rule + "DebitNote/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }
    public static class AccountRouter
    {
      public const string prefix = Rule + "Account/";

      public const string GetAccountTypeById = prefix + "GetAccountTypeById/{Id}";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string GetMainAccountsList = prefix + "MainAccountsList";

      public const string Edit = prefix + "Edit";

      public const string GetSecondaryAccountById = prefix + "GetSecondaryAccountById/{Id}";
      public const string GetPrimaryAccountById = prefix + "GetPrimaryAccountById/{Id}";

      public const string Delete = prefix + "Delete/{Id}";

    }

    public static class JournalEntryRouter
    {
      public const string prefix = Rule + "JournalEntry/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";



    }

    public static class CostCenterRouter
    {
      public const string prefix = Rule + "CostCenter/";

      public const string GetCostCenterTypeById = prefix + "GetCostCenterTypeById/{Id}";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string GetMainCostCentersList = prefix + "MainCostCentersList";

      public const string Edit = prefix + "Edit";

      public const string GetSecondaryCostCenterById = prefix + "GetSecondaryCostCenterById/{Id}";
      public const string GetPrimaryCostCenterById = prefix + "GetPrimaryCostCenterById/{Id}";

      public const string Delete = prefix + "Delete/{Id}";

    }



    public static class CustomerRouter
    {
      public const string prefix = Rule + "Customer/";

      public const string GetCustomerTypeById = prefix + "GetCustomerTypeById/{Id}";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string GetIndividualCustomerById = prefix + "GetIndividualCustomerById/{Id}";
      public const string GetCommercialCustomerById = prefix + "GetCommercialCustomerById/{Id}";

      public const string Delete = prefix + "Delete/{Id}";

    }

    public static class CustomerClassificationRouter
    {
      public const string prefix = Rule + "CustomerClassification/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

      public const string Edit = prefix + "Edit";

      public const string Delete = prefix + "Delete/{Id}";


    }
    public static class ContactListRouter
    {
      public const string prefix = Rule + "ContactList/";

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


    public static class EnrollmentRouter
    {
      public const string prefix = Rule + "Enrollment/";

      public const string GetList = prefix + "List";

      public const string GetById = prefix + "{Id}";

      public const string Create = prefix + "Create";

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
