using System.Security.Claims;

namespace Name.Data.Helpers
{
  public static class ClaimsStore
  {
    public static List<Claim> Accountsclaims = new()
        {
            new Claim("Add New Assets","false"),
            new Claim("View Cost Centers","false"),
            new Claim("Cost Center Management","false"),
            new Claim("Manage Closed Periods","false"),
            new Claim("View Closed Periods","false"),
            new Claim("Manage Journal Accounts","false"),
            new Claim("View All Journals","false"),
            new Claim("View Own Journals","false"),
            new Claim("Add/Edit All Journals","false"),
            new Claim("Add/Edit/Delete Own Journals","false"),
            new Claim("Add/Edit Draft Journals","false"),
            new Claim("Delete Journals","false")
        };


    public static List<Claim> SalesClaims = new()
        {
            new Claim("Add New Invoices to All Clients","false"),
            new Claim("Add New Invoices to His Clients","false"),
            new Claim("Edit & Delete All Invoices","false"),
            new Claim("Edit & Delete His Own (Created) Invoices","false"),
            new Claim("View His Own Invoices","false"),
            new Claim("View All Invoices","false"),
            new Claim("Generate Tax Reports","false"),
            new Claim("Change Sales Person","false"),
            new Claim("Invoice All Products","false"),
            new Claim("View Invoice Profit","false"),
            new Claim("Edit Invoice Date","false"),
            new Claim("Add Payments to All Invoices","false"),
            new Claim("Add Payments to His Own (Created) Invoices","false"),
            new Claim("Edit Payment Options","false"),
            new Claim("Edit & Remove All Payments","false"),
            new Claim("Edit & Remove His Payments","false"),
            new Claim("Add New Estimates to All Clients","false"),
            new Claim("Add New Estimates to His Own Clients","false"),
            new Claim("View All Estimates","false"),
            new Claim("View His Own Estimates","false"),
            new Claim("Edit & Delete All Estimates","false"),
            new Claim("Edit & Delete His Own (Created) Estimates","false"),
            new Claim("Add New Sales Order To All Clients","false"),
            new Claim("Add New Sales Order To His Own Clients","false"),
            new Claim("Edit & Delete All Sales Orders","false"),
            new Claim("Edit & Delete His Own Sales Orders","false"),
            new Claim("View All Sales Orders","false"),
            new Claim("View His Own Sales Orders","false"),
            new Claim("Add New Debit Note To All Clients","false"),
            new Claim("Add New Debit Note To His Clients","false"),
            new Claim("Edit & Delete All Debit Notes","false"),
            new Claim("Edit & Delete His Own Debit Notes","false"),
            new Claim("View All Debit Notes","false"),
            new Claim("View His Own Debit Notes","false")
        };


    public static List<Claim> ProductsClaims = new()
        {
            new Claim("Add New Product","false"),
            new Claim("View All Products","false"),
            new Claim("View His Own (Created) Products","false"),
            new Claim("Edit & Delete All Products","false"),
            new Claim("Edit & Delete His Own (Created) Products","false"),
            new Claim("Add/Edit Price List","false"),
            new Claim("View Price List","false"),
            new Claim("Delete Price List","false")
        };


    public static List<Claim> EmployeesClaims = new()
{
    new Claim("Add New User/Employee","false"),
    new Claim("Edit & Delete User/Employee","false"),
    new Claim("Add New User Role","false"),
    new Claim("Edit/Delete User Roles","false"),
    new Claim("View Employee Profile","false")
};

    public static List<Claim> OrganizationalStructureClaims = new()
{
    new Claim("Manage HR System","false")
};



    public static List<Claim> PayrollClaims = new()
{
    new Claim("Manage Payroll Settings","false"),
    new Claim("View Pay Run","false"),
    new Claim("View His Own Payslip","false"),
    new Claim("Create Pay Run","false"),
    new Claim("Delete Pay Run","false"),
    new Claim("Approve Payslips","false"),
    new Claim("Delete Payslips","false"),
    new Claim("Edit Payslips","false"),
    new Claim("Pay Payslips","false"),
    new Claim("Delete Pay Run Payments","false"),
    new Claim("Receive Payroll Contract Notification","false"),
    new Claim("Contract Notifications","false"),
    new Claim("Manage Loans & Installments","false"),
    new Claim("Add Contracts","false"),
    new Claim("View His Own Contracts","false"),
    new Claim("View All Contracts","false"),
    new Claim("Edit/Delete His Own Contracts","false"),
    new Claim("Edit/Delete All Contracts","false")
};



    public static List<Claim> PurchaseManagementClaims = new()
{
    new Claim("Add Requisition","false"),
    new Claim("Edit Requisition","false"),
    new Claim("View Requisition","false"),
    new Claim("View Stock Transaction Price","false"),
    new Claim("Edit Stock Transaction Price","false"),
    new Claim("Add New Purchase Invoice","false"),
    new Claim("Edit & Delete All Purchase Invoices","false"),
    new Claim("Edit & Delete His Own (Created) Purchase Invoices","false"),
    new Claim("View His Own (Created) Purchase Invoices","false"),
    new Claim("View All Purchase Invoices","false"),
    new Claim("Add New Supplier","false"),
    new Claim("View His Own (Created) Suppliers","false"),
    new Claim("View All Suppliers","false"),
    new Claim("Edit & Delete His Own (Created) Suppliers","false"),
    new Claim("Edit & Delete All Suppliers","false"),
    new Claim("Allow to Sell Under Product Minimum Price","false"),
    new Claim("Adjust Product Inventory","false"),
    new Claim("Track Inventory","false"),
    new Claim("Transfer Stock","false")
};



    public static List<Claim> FinanceClaims = new()
{
    new Claim("Add Expense","false"),
    new Claim("Edit & Delete All Expenses","false"),
    new Claim("Edit & Delete His Own (Created) Expenses","false"),
    new Claim("View All Expenses","false"),
    new Claim("View His Own (Created) Expenses","false"),
    new Claim("Add/Edit/Delete Draft Expenses","false"),
    new Claim("Change Default Treasury","false"),
    new Claim("View His Own Treasury","false"),
    new Claim("Add Income","false"),
    new Claim("Edit & Delete All Incomes","false"),
    new Claim("Edit & Delete His Own (Created) Incomes","false"),
    new Claim("View All Incomes","false"),
    new Claim("View His Own (Created) Incomes","false"),
    new Claim("Add Expense/Income Category","false"),
    new Claim("Add/Edit/Delete Draft Incomes","false")
};


  }
}
