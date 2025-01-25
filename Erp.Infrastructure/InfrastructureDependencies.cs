using Erp.Infrastructure.Abstracts;
using Erp.Infrastructure.Repositories;
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



      services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      return services;
    }
  }
}
