using JwtAuthentication.Core.Entities.Concrete;
using System.Linq.Expressions;

namespace JwtAuthentication.DataAccess.Abstract;

public interface IUserDal
{
    void Add(User user);
    User Get(Expression<Func<User, bool>> filter);
    User GetByEmail(string email);
}
