using AutoMapper;
using Erp.Core.Features.Supplier.Queries.Models;
using Erp.Core.Features.Supplier.Queries.Results;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Queries.Handlers
{
  public class SupplierQueryHandler : ResponseHandler,
    IRequestHandler<GetSupplierByIdQuery, Response<GetSupplierByIdResult>>,
    IRequestHandler<GetSupplierListQuery, Response<List<GetSupplierListResult>>>
  {
    #region Fields
    private readonly ISupplierService _SupplierService;
    private readonly IJournalEntryService _journalEntryService;

    private readonly IMapper _mapper;
    #endregion
    public SupplierQueryHandler(ISupplierService SupplierService,
      IMapper mapper,
      IJournalEntryService journalEntryService)
    {
      _mapper = mapper;
      _SupplierService = SupplierService;
      _journalEntryService = journalEntryService;
    }

    public async Task<Response<GetSupplierByIdResult>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
    {
      var Supplier = await _SupplierService.GetSupplierByIdAsync(request.Id);


      if (Supplier == null)
      {
        return NotFound<GetSupplierByIdResult>("Supplier Not Found");
      }
      else
      {
        var SupplierMapper = _mapper.Map<GetSupplierByIdResult>(Supplier);
        SupplierMapper.BalanceDue = Supplier.Account.Balance;

        decimal pre = 0, total = 0, AmountPaid = 0;
        foreach (var item in Supplier.Account.journalEntrys)
        {

          decimal amount = 0;
          foreach (var detail in item.details)
          {
            if (detail.AccountID == Supplier.AccountId)
            {
              if (detail.Credit > 0)
              {
                amount = detail.Credit;
                total += detail.Credit;
              }
              else
              {
                amount = -detail.Debit;
                AmountPaid += detail.Debit;
              }
            }
          }
          pre += amount;
          SupplierMapper.transactionDtos.Add(new TransactionDto()
          {
            DateTime = item.EntryDate,
            Transaction = item.Description,
            Amount = amount,
            BalanceDue = pre,
            Id = int.Parse(item.Description.Split('#')[1]),
            Type = item.Description.Split('#')[0]
          });
        }
        SupplierMapper.Total = total;
        SupplierMapper.PaidToDate = AmountPaid;


        return Success(SupplierMapper);
      }
    }

    public async Task<Response<List<GetSupplierListResult>>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
    {
      var SupplierList = await _SupplierService.GetSuppliersListAsync();

      var SupplierListMapper = _mapper.Map<List<GetSupplierListResult>>(SupplierList);

      return Success(SupplierListMapper);
    }
  }
}
