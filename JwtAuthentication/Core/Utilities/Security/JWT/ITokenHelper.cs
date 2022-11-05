using JwtAuthentication.Core.Entities.Concrete;

namespace JwtAuthentication.Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user);
}
