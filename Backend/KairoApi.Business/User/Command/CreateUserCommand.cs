using AutoMapper;
using KairoApi.Db.UnitOfWork;
using KairoApi.Dto;
using MediatR;
using KairoApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace KairoApi.Business.User.Command;

public class CreateUserCommand : UserInput, IRequest
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IKairoApiUnitOfWork _unitOfWork;
        

        public CreateUserCommandHandler(
            IMapper mapper,
            IKairoApiUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async System.Threading.Tasks.Task  Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.password = BCrypt.Net.BCrypt.HashPassword(request.password); 
            var data = _mapper.Map<UserDao>(request);
            
            data.CreatedAt = DateTime.UtcNow;
            data.UpdatedAt = DateTime.UtcNow;
            data.IsVerified = false;
            
            await _unitOfWork.UserRepository.AddAndSaveAsync(data);
        }
    }
}