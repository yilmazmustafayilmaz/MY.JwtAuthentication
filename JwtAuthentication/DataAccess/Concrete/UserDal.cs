using JwtAuthentication.Core.Entities.Concrete;
using JwtAuthentication.DataAccess.Abstract;
using JwtAuthentication.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtAuthentication.DataAccess.Concrete;

public class UserDal : IUserDal
{
    public void Add(User user)
    {
        using (DatabaseContext context = new DatabaseContext())
        {
            context.Add(user);
            context.SaveChanges();
        }
    }

    public User Get(Expression<Func<User, bool>> filter)
    {
        using (DatabaseContext context = new DatabaseContext())
        {
            return context.Set<User>().SingleOrDefault(filter);
        }
    }

    public User GetByEmail(string Email)
    {
        using (DatabaseContext context = new DatabaseContext())
        {
            return Get(x => x.Email == Email);
        }
    }
}
