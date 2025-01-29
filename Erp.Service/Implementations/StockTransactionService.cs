using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class StockTransactionService : IStockTransactionService
  {
    private readonly IStockTransactionRepository _stockTransactionRepository;

    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;
    public StockTransactionService(IStockTransactionRepository stockTransactionRepository, IProductService productService, IWarehouseService warehouseService)
    {
      _stockTransactionRepository = stockTransactionRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddStockTransaction(StockTransaction StockTransaction)
    {
      var newStockTransaction = await _stockTransactionRepository.AddAsync(StockTransaction);
      if (newStockTransaction != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(StockTransaction StockTransaction)
    {
      try
      {
        await _stockTransactionRepository.DeleteAsync(StockTransaction);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the StockTransaction : " + ex.Message;
      }
    }

    public async Task<StockTransaction> GetStockTransactionByIdAsync(int id)
    {
      var StockTransaction = _stockTransactionRepository.GetTableNoTracking().Where(x => x.StockTransactionId == id).SingleOrDefault();
      StockTransaction.Warehouse = await _warehouseService.GetWarehouseByIdAsync(StockTransaction.WarehouseId);
      StockTransaction.Product = await _productService.GetProductByIdAsync(StockTransaction.ProductId);

      return StockTransaction;
    }

    public async Task<List<StockTransaction>> GetStockTransactionsListAsync()
    {
      var StockTransactions = _stockTransactionRepository.GetTableNoTracking().ToList();
      foreach (var StockTransaction in StockTransactions)
      {
        StockTransaction.Warehouse = await _warehouseService.GetWarehouseByIdAsync(StockTransaction.WarehouseId);
        StockTransaction.Product = await _productService.GetProductByIdAsync(StockTransaction.ProductId);
      }

      return StockTransactions;
    }

    public async Task<string> UpdateAsync(StockTransaction StockTransaction)
    {
      var transact = _stockTransactionRepository.BeginTransaction();
      try
      {
        await _stockTransactionRepository.UpdateAsync(StockTransaction);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
