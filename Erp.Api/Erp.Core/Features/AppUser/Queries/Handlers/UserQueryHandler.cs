using AutoMapper;
using Name.Core.Bases;
using Name.Core.Features.UserBase.Queries.Models;
using Name.Core.Features.UserBase.Queries.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;


using US = Name.Data.Entities;


namespace Name.Core.Features.UserBase.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>

    {

        #region Fields
        private readonly UserManager<US.UserBase> _userManager;

        private readonly IMapper _mapper;
        #endregion

        public UserQueryHandler(UserManager<US.UserBase> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var usersMaper = _mapper.Map<List<GetUserListResponse>>(_userManager.Users.ToList());
            return Success(usersMaper);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userMaper = _mapper.Map<GetUserByIdResponse>(await _userManager.FindByIdAsync(request.Id));

            if (userMaper == null)
            {
                return NotFound<GetUserByIdResponse>($"there is no user with id = {request.Id}");
            }
            else
            {
                return Success(userMaper);
            }
        }
    }
}
