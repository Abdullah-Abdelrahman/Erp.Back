using Erp.Data.Entities;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure
{
  public class DataSeeder
  {
    private readonly ApplicationDBContext _context;

    public DataSeeder(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task Seed(string tenantId)
    {

      if (!_context.primaryAccounts.IgnoreQueryFilters().Where(p => p.TenantId == tenantId).Any())
      {

        var transact = _context.Database.BeginTransaction();
        try
        {
          Console.ForegroundColor = ConsoleColor.Green; // Change text color to Green
          Console.WriteLine("Seeeeeeeeeeeeeeeeeeeeeeeeeeeding data... : " + tenantId);
          Console.ResetColor();

          ///////////////////////////////////////Level 1///////////////////////////
          #region level_1

          var assestsAcc = new PrimaryAccount
          {
            AccountName = "Assets",
            Type = AccountType.debtor,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(assestsAcc);



          var OpponentsAcc = new PrimaryAccount
          {
            AccountName = "Opponents",
            Type = AccountType.creditor,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(OpponentsAcc);


          var CapitalAndEquityAcc = new PrimaryAccount
          {
            AccountName = "Capital and Equity",
            Type = AccountType.creditor,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(CapitalAndEquityAcc);

          var RevenueAcc = new PrimaryAccount
          {
            AccountName = "Revenue",
            Type = AccountType.creditor,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(RevenueAcc);

          var ExpensesAcc = new PrimaryAccount
          {
            AccountName = "Expenses",
            Type = AccountType.debtor,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(ExpensesAcc);

          await _context.SaveChangesAsync();

          #endregion

          ///////////////////////////////////////Level 2///////////////////////////
          #region Level_2
          //Assets
          var FixassestsAcc = new PrimaryAccount
          {
            AccountName = "Fixed assets",
            Type = AccountType.debtor,
            ParentAccountID = assestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(FixassestsAcc);

          var CurrentAssetsAcc = new PrimaryAccount
          {
            AccountName = "Current Assets",
            Type = AccountType.debtor,
            ParentAccountID = assestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(CurrentAssetsAcc);
          //Opponents
          var CurrentLiabilitiesAcc = new PrimaryAccount
          {
            AccountName = "Current Liabilities",
            Type = AccountType.creditor,
            ParentAccountID = OpponentsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(CurrentLiabilitiesAcc);

          var LongTermLiabilitiesAcc = new PrimaryAccount
          {
            AccountName = "Long-term Liabilities",
            Type = AccountType.creditor,
            ParentAccountID = OpponentsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(LongTermLiabilitiesAcc);
          //CapitalAndEquity
          var CapitalAcc = new SecondaryAccount
          {
            AccountName = "Capital",
            Type = AccountType.creditor,
            ParentAccountID = CapitalAndEquityAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(CapitalAcc);

          var RetainedEarningsAcc = new SecondaryAccount
          {
            AccountName = "Retained Earnings and Losses",
            Type = AccountType.creditor,
            ParentAccountID = CapitalAndEquityAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(RetainedEarningsAcc);
          //Revenue
          var SalesRevenueAcc = new PrimaryAccount
          {
            AccountName = "Sales Revenue",
            Type = AccountType.creditor,
            ParentAccountID = RevenueAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(SalesRevenueAcc);

          var OtherRevenuesAcc = new PrimaryAccount
          {
            AccountName = "Other Revenues",
            Type = AccountType.creditor,
            ParentAccountID = RevenueAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(OtherRevenuesAcc);
          //Expenses
          var CostOfSalesAcc = new PrimaryAccount
          {
            AccountName = "Cost of Sales",
            Type = AccountType.debtor,
            ParentAccountID = ExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(CostOfSalesAcc);

          var GeneralExpensesAcc = new PrimaryAccount
          {
            AccountName = "General and Administrative Expenses",
            Type = AccountType.debtor,
            ParentAccountID = ExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(GeneralExpensesAcc);

          var DepreciationExpensesAcc = new PrimaryAccount
          {
            AccountName = "Depreciation Expenses",
            Type = AccountType.debtor,
            ParentAccountID = ExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(DepreciationExpensesAcc);

          var OtherExpensesAcc = new PrimaryAccount
          {
            AccountName = "Other Expenses",
            Type = AccountType.debtor,
            ParentAccountID = ExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(OtherExpensesAcc);

          await _context.SaveChangesAsync();


          #endregion
          ///////////////////////////////////////Level 3///////////////////////////
          //Fixed Assets
          #region Level_3
          #region Fixed Assets Accounts
          var furnitureAcc = new PrimaryAccount
          {
            AccountName = "Furniture",
            Type = AccountType.debtor,
            ParentAccountID = FixassestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(furnitureAcc);

          var equipmentAcc = new PrimaryAccount
          {
            AccountName = "Equipment and Tools",
            Type = AccountType.debtor,
            ParentAccountID = FixassestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(equipmentAcc);

          var vehiclesAcc = new PrimaryAccount
          {
            AccountName = "Vehicles",
            Type = AccountType.debtor,
            ParentAccountID = FixassestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(vehiclesAcc);

          var buildingsAcc = new PrimaryAccount
          {
            AccountName = "Buildings",
            Type = AccountType.debtor,
            ParentAccountID = FixassestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(buildingsAcc);

          var landAcc = new PrimaryAccount
          {
            AccountName = "Land",
            Type = AccountType.debtor,
            ParentAccountID = FixassestsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(landAcc);
          #endregion

          //Current Assets
          #region Current Assets Accounts
          var treasuryAcc = new PrimaryAccount
          {
            AccountName = "Treasury",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(treasuryAcc);

          var bankAcc = new PrimaryAccount
          {
            AccountName = "Bank",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(bankAcc);

          var inventoryAcc = new PrimaryAccount
          {
            AccountName = "Inventory",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(inventoryAcc);

          var receivablesAcc = new PrimaryAccount
          {
            AccountName = "Receivables",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(receivablesAcc);

          var employeeAdvancesAcc = new PrimaryAccount
          {
            AccountName = "Employee Advances",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(employeeAdvancesAcc);

          var cashNotesAcc = new PrimaryAccount
          {
            AccountName = "Cash Notes",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(cashNotesAcc);

          var cashSurplusAcc = new SecondaryAccount
          {
            AccountName = "Cash Surplus and Deficit",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(cashSurplusAcc);

          var currencyExchangeAcc = new SecondaryAccount
          {
            AccountName = "Currency Exchange",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(currencyExchangeAcc);

          var purchasesAcc = new SecondaryAccount
          {
            AccountName = "Purchases",
            Type = AccountType.debtor,
            ParentAccountID = CurrentAssetsAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(purchasesAcc);
          #endregion
          //Current Liabilities
          #region Current Liabilities Accounts
          var payablesAcc = new PrimaryAccount
          {
            AccountName = "Payables",
            Type = AccountType.creditor,
            ParentAccountID = CurrentLiabilitiesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(payablesAcc);

          var notesPayableAcc = new PrimaryAccount
          {
            AccountName = "Notes Payable",
            Type = AccountType.creditor,
            ParentAccountID = CurrentLiabilitiesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(notesPayableAcc);

          var accumulatedDepreciationAcc = new PrimaryAccount
          {
            AccountName = "Accumulated Depreciation",
            Type = AccountType.creditor,
            ParentAccountID = CurrentLiabilitiesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(accumulatedDepreciationAcc);

          var openingBalancesAcc = new SecondaryAccount
          {
            AccountName = "Opening Balances",
            Type = AccountType.creditor,
            ParentAccountID = CurrentLiabilitiesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(openingBalancesAcc);
          #endregion
          //Sales Revenue
          #region Sales Revenue Accounts
          var salesAcc = new SecondaryAccount
          {
            AccountName = "Sales",
            Type = AccountType.creditor,
            ParentAccountID = SalesRevenueAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(salesAcc);

          var salesReturnsAcc = new SecondaryAccount
          {
            AccountName = "Sales Returns",
            Type = AccountType.creditor,
            ParentAccountID = SalesRevenueAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(salesReturnsAcc);
          #endregion
          //Other Revenues
          #region Other Revenue Accounts
          var otherRevenueDetailAcc = new SecondaryAccount
          {
            AccountName = "Other Revenue",
            Type = AccountType.creditor,
            ParentAccountID = OtherRevenuesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(otherRevenueDetailAcc);

          var capitalGainsLossesAcc = new SecondaryAccount
          {
            AccountName = "Capital Gains and Losses",
            Type = AccountType.creditor,
            ParentAccountID = OtherRevenuesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(capitalGainsLossesAcc);
          #endregion

          //Cost of Sales
          #region Cost of Sales Accounts
          var costOfSalesDetailAcc = new SecondaryAccount
          {
            AccountName = "Cost of Sales",
            Type = AccountType.debtor,
            ParentAccountID = CostOfSalesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(costOfSalesDetailAcc);

          var purchaseShippingAcc = new SecondaryAccount
          {
            AccountName = "Purchase Shipping",
            Type = AccountType.debtor,
            ParentAccountID = CostOfSalesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(purchaseShippingAcc);

          var allowedDiscountAcc = new SecondaryAccount
          {
            AccountName = "Allowed Discount",
            Type = AccountType.debtor,
            ParentAccountID = CostOfSalesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(allowedDiscountAcc);
          #endregion
          //General and Administrative Expenses
          #region General and Administrative Expenses
          var rentAcc = new SecondaryAccount
          {
            AccountName = "Rent",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(rentAcc);

          var electricityAcc = new SecondaryAccount
          {
            AccountName = "Electricity",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(electricityAcc);

          var telephoneInternetAcc = new SecondaryAccount
          {
            AccountName = "Telephone and Internet",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(telephoneInternetAcc);

          var maintenanceAcc = new SecondaryAccount
          {
            AccountName = "Maintenance",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(maintenanceAcc);

          var waterAcc = new SecondaryAccount
          {
            AccountName = "Water",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(waterAcc);

          var governmentFeesAcc = new SecondaryAccount
          {
            AccountName = "Government Fees",
            Type = AccountType.debtor,
            ParentAccountID = GeneralExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(governmentFeesAcc);
          #endregion
          //other Expenses
          #region Other Expenses
          var otherExpensesDetailAcc = new SecondaryAccount
          {
            AccountName = "Other Expenses",
            Type = AccountType.debtor,
            ParentAccountID = OtherExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(otherExpensesDetailAcc);

          var badDebtsAcc = new SecondaryAccount
          {
            AccountName = "Bad Debts",
            Type = AccountType.debtor,
            ParentAccountID = OtherExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(badDebtsAcc);

          var inventorySurplusDeficitAcc = new SecondaryAccount
          {
            AccountName = "Inventory Surplus and Deficit",
            Type = AccountType.debtor,
            ParentAccountID = OtherExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(inventorySurplusDeficitAcc);

          var revaluationAcc = new SecondaryAccount
          {
            AccountName = "Revaluation",
            Type = AccountType.debtor,
            ParentAccountID = OtherExpensesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(revaluationAcc);
          #endregion

          await _context.SaveChangesAsync();

          #endregion
          ///////////////////////////////////////Level 4///////////////////////////
          #region Level_4
          #region Treasury Accounts
          var mainTreasuryAcc = new SecondaryAccount
          {
            AccountName = "Main Treasury",
            Type = AccountType.debtor,
            ParentAccountID = treasuryAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(mainTreasuryAcc);

          var testTreasuryAcc = new SecondaryAccount
          {
            AccountName = "Test",
            Type = AccountType.debtor,
            ParentAccountID = treasuryAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(testTreasuryAcc);
          #endregion

          #region Receivables Accounts
          var customersAcc = new PrimaryAccount
          {
            AccountName = "Customers",
            Type = AccountType.debtor,
            ParentAccountID = receivablesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(customersAcc);

          var otherDebtorsAcc = new SecondaryAccount
          {
            AccountName = "Other Receivables",
            Type = AccountType.debtor,
            ParentAccountID = receivablesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(otherDebtorsAcc);
          #endregion

          #region Payables Accounts
          var suppliersAcc = new PrimaryAccount
          {
            AccountName = "Suppliers",
            Type = AccountType.creditor,
            ParentAccountID = payablesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(suppliersAcc);

          var shippingCompaniesAcc = new PrimaryAccount
          {
            AccountName = "Shipping Companies",
            Type = AccountType.creditor,
            ParentAccountID = payablesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<PrimaryAccount>().AddAsync(shippingCompaniesAcc);

          var OtherPayablesAcc = new SecondaryAccount
          {
            AccountName = "Other Payables",
            Type = AccountType.creditor,
            ParentAccountID = payablesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(OtherPayablesAcc);
          #endregion

          await _context.SaveChangesAsync();

          #endregion
          ///////////////////////////////////////Level 5///////////////////////////
          #region Level_5
          #region Shipping Companies Accounts
          var salesShippingAcc = new SecondaryAccount
          {
            AccountName = "Sales Shipping",
            Type = AccountType.creditor,
            ParentAccountID = shippingCompaniesAcc.AccountID,
            TenantId = tenantId
          };
          await _context.Set<SecondaryAccount>().AddAsync(salesShippingAcc);
          #endregion

          await _context.SaveChangesAsync();


          #endregion
          await transact.CommitAsync();

        }
        catch (Exception ex)
        {
          await transact.RollbackAsync();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(MessageCenter.CrudMessage.Falied + ex.Message);
          Console.ResetColor();
        }
      }


      if (!_context.Treasuries.IgnoreQueryFilters().Where(t => t.TenantId == tenantId).Any())
      {
        var transact = _context.Database.BeginTransaction();
        try
        {
          Console.ForegroundColor = ConsoleColor.Green; // Change text color to Green
          Console.WriteLine("Seeeeeeeeeeeeeeeeeeeeeeeeeeeding data... : " + tenantId);
          Console.ResetColor();
          var aacId = (await _context.Set<SecondaryAccount>().IgnoreQueryFilters()
            .Where(x => x.TenantId == tenantId && x.AccountName == "Main Treasury").SingleAsync()).AccountID;
          var mainT = new Treasury()
          {
            Name = "Main Treasury",
            AccountId = aacId,
            TenantId = tenantId
          };
          await _context.Set<Treasury>().AddAsync(mainT);


          await _context.SaveChangesAsync();

          await transact.CommitAsync();

        }
        catch (Exception ex)
        {
          await transact.RollbackAsync();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(MessageCenter.CrudMessage.Falied + ex.Message);
          Console.ResetColor();
        }

      }



      if (!_context.voucherStatuses.Any())
      {
        var transact = _context.Database.BeginTransaction();
        try
        {


          var Accepted = new VoucherStatus()
          {
            Name = "Accepted",
            Description = "",
          };
          await _context.Set<VoucherStatus>().AddAsync(Accepted);

          var UnderDelivery = new VoucherStatus()
          {
            Name = "Under Delivery",
            Description = "",
          };
          await _context.Set<VoucherStatus>().AddAsync(UnderDelivery);



          var Rejected = new VoucherStatus()
          {
            Name = "Rejected",
            Description = "",
          };
          await _context.Set<VoucherStatus>().AddAsync(Rejected);

          await _context.SaveChangesAsync();

          await transact.CommitAsync();

        }
        catch (Exception ex)
        {
          await transact.RollbackAsync();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(MessageCenter.CrudMessage.Falied + ex.Message);
          Console.ResetColor();
        }

      }




      if (!_context.paymentStatuses.Any())
      {
        var transact = _context.Database.BeginTransaction();
        try
        {


          var Paid = new PaymentStatus()
          {
            Name = "Paid",
            Description = "",
          };
          await _context.Set<PaymentStatus>().AddAsync(Paid);

          var PartiallyPaid = new PaymentStatus()
          {
            Name = "Partially Paid",
            Description = "",
          };
          await _context.Set<PaymentStatus>().AddAsync(PartiallyPaid);



          var Unpaid = new PaymentStatus()
          {
            Name = "Unpaid",
            Description = "",
          };
          await _context.Set<PaymentStatus>().AddAsync(Unpaid);

          await _context.SaveChangesAsync();

          await transact.CommitAsync();

        }
        catch (Exception ex)
        {
          await transact.RollbackAsync();
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(MessageCenter.CrudMessage.Falied + ex.Message);
          Console.ResetColor();
        }

      }



    }
  }

}
