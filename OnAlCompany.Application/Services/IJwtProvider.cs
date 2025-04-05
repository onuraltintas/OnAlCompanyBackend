using OnAlCompany.Application.Features.Auth.Login;
using OnAlCompany.Domain.Entities;

namespace OnAlCompany.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
