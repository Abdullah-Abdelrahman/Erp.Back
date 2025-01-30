using AutoMapper;
using Erp.Core.Features.ContactList.Queries.Models;
using Erp.Core.Features.ContactList.Queries.Results;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Queries.Handlers
{
  public class ContactListQueryHandler : ResponseHandler, IRequestHandler<GetContactListByIdQuery, Response<GetContactListByIdResult>>, IRequestHandler<GetContactListListQuery, Response<List<GetContactListByIdResult>>>
  {
    #region Fields
    private readonly IContactListService _ContactListService;

    private readonly IMapper _mapper;
    #endregion
    public ContactListQueryHandler(IContactListService ContactListService, IMapper mapper)
    {
      _mapper = mapper;
      _ContactListService = ContactListService;
    }

    public async Task<Response<GetContactListByIdResult>> Handle(GetContactListByIdQuery request, CancellationToken cancellationToken)
    {
      var ContactList = await _ContactListService.GetContactListByIdAsync(request.Id);


      if (ContactList == null)
      {
        return NotFound<GetContactListByIdResult>("ContactList Not Found");
      }
      else
      {
        var ContactListMapper = _mapper.Map<GetContactListByIdResult>(ContactList);
        return Success(ContactListMapper);
      }
    }

    public async Task<Response<List<GetContactListByIdResult>>> Handle(GetContactListListQuery request, CancellationToken cancellationToken)
    {
      var ContactListList = await _ContactListService.GetContactListsListAsync();

      var ContactListListMapper = _mapper.Map<List<GetContactListByIdResult>>(ContactListList);

      return Success(ContactListListMapper);
    }
  }
}
