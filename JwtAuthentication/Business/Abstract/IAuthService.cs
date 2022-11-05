using JwtAuthentication.Core.Entities.Concrete;
using JwtAuthentication.Core.Entities.DTOs;
using JwtAuthentication.Core.Utilities.Security.JWT;

namespace JwtAuthentication.Business.Abstract;
public interface IAuthService
{
    User Register(UserForRegisterDto userForRegisterDto);
    User Login(UserForLoginDto userForLoginDto);
    bool UserExists(string Email);
    AccessToken CreateAccessToken(User user);
}

