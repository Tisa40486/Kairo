using AutoMapper;
using KairoApi.Db.DbContexts;
using KairoApi.Db.UnitOfWork;
using KairoApi.Dto;
using MediatR;

namespace KairoApi.Business.User.Query;

public class GetUserByIdQuery : IRequest<UserResponse>
{
    public int Id { get; set; }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IKairoApiUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(
            IKairoApiUnitOfWork uow,
            IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        
        public async Task<UserResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.UserRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserResponse>(data);
        }
    }
}