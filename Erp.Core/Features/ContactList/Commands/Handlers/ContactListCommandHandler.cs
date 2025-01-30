using AutoMapper;
using Erp.Core.Features.ContactList.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.ContactList.Commands.Handlers
{

  public class ContactListCommandHandler : ResponseHandler,
    IRequestHandler<AddContactListCommand, Response<string>>,
     IRequestHandler<EditContactListCommand, Response<string>>,
     IRequestHandler<DeleteContactListCommand, Response<string>>
  {
    private readonly IContactListService _ContactListService;
    private readonly IMapper _mapper;

    public ContactListCommandHandler(IContactListService ContactListService, IMapper mapper)
    {
      _ContactListService = ContactListService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddContactListCommand request, CancellationToken cancellationToken)
    {
      var ContactListMapper = _mapper.Map<Entitis.CustomersModule.ContactList>(request);
      var result = await _ContactListService.AddContactListAsync(ContactListMapper);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Name Exist Befor");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditContactListCommand request, CancellationToken cancellationToken)
    {
      var ContactListMapper = _mapper.Map<Entitis.CustomersModule.ContactList>(request);
      var result = await _ContactListService.UpdateAsync(ContactListMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteContactListCommand request, CancellationToken cancellationToken)
    {
      var ContactListInDB = await _ContactListService.GetContactListByIdAsync(request.Id);


      if (ContactListInDB == null)
      {
        return NotFound<string>("There is no ContactList with this id");
      }
      else
      {

        var result = await _ContactListService.DeleteAsync(ContactListInDB);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>("Somthing bad happened");
        }



      }
    }
  }
}

