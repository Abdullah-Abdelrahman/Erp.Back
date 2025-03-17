using AutoMapper;
using Erp.Core.Features.Payment.Commands.Models;
using Erp.Service.Abstracts.CommonUse;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Commands.Handlers
{

  public class PaymentCommandHandler : ResponseHandler,
    IRequestHandler<AddSupplierPaymentCommand, Response<string>>,
     IRequestHandler<AddClientPaymentCommand, Response<string>>,
     IRequestHandler<DeleteClientPaymentCommand, Response<string>>,
     IRequestHandler<DeleteSupplierPaymentCommand, Response<string>>

  {
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentCommandHandler(IPaymentService paymentService, IMapper mapper)
    {
      _paymentService = paymentService;
      _mapper = mapper;
    }

    public Task<Response<string>> Handle(AddSupplierPaymentCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<Response<string>> Handle(AddClientPaymentCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<Response<string>> Handle(DeleteClientPaymentCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<Response<string>> Handle(DeleteSupplierPaymentCommand request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}

