using Azure.Core;
using KairoApi.Db.UnitOfWork;
using KairoApi.Dto;
using MediatR;

namespace KairoApi.Business.User.Command;

public class LoginUserCommand : AuthUserInput, IRequest<string>
{

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IKairoApiUnitOfWork _kairoApiUnitOfWork;
        private readonly TokenService _tokenService;

        public LoginUserCommandHandler(
            IKairoApiUnitOfWork kairoApiUnitOfWork,
            TokenService tokenService)
        {
            _kairoApiUnitOfWork = kairoApiUnitOfWork;
            _tokenService = tokenService;
        }
        public async System.Threading.Tasks.Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _kairoApiUnitOfWork.UserRepository.GetUserByEmailAsync(request.email);
            if (user == null)
                throw new Exception("Error, User not found");
            
            var check = BCrypt.Net.BCrypt.Verify(request.password, user.Password);
            if (!check)
                throw new Exception("Error, Wrong password");
            
            
           
            
            if (user.Email != request.email )
                throw new Exception("Error, Wrong email");

            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}