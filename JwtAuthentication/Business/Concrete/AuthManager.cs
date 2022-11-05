using JwtAuthentication.Business.Abstract;
using JwtAuthentication.Core.Entities.Concrete;
using JwtAuthentication.Core.Entities.DTOs;
using JwtAuthentication.Core.Utilities.Security.Hashing;
using JwtAuthentication.Core.Utilities.Security.JWT;
using JwtAuthentication.DataAccess.Abstract;

namespace JwtAuthentication.Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserDal _userDal;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(IUserDal userDal, ITokenHelper tokenHelper)
    {
        _userDal = userDal;
        _tokenHelper = tokenHelper;
    }

    public AccessToken CreateAccessToken(User user)
    {
        var accessToken = _tokenHelper.CreateToken(user);
        return accessToken;
    }

    public User Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userDal.GetByEmail(userForLoginDto.Email);
        if (userToCheck == null)
            return userToCheck;

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            throw new Exception();

        return userToCheck;
    }

    public User Register(UserForRegisterDto userForRegisterDto)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        _userDal.Add(user);
        return user;
    }

    public bool UserExists(string email)
    {
        return _userDal.GetByEmail(email) != null ? false : true;
  
    }
}
