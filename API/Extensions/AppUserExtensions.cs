using API.DTO;
using API.Entities;
using API.Interfaces;
using API.Services;

namespace API.Extensions
{
    public  static class AppUserExtensions
    {

        public static UserDTO ToDo(this AppUser user, ITokenService tokenService)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}
