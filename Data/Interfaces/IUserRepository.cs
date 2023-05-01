using FinanceTracker.Models;
using System.Linq.Expressions;

namespace FinanceTracker.Data.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);

        bool CheckIfUserExist(User user);

        User? GetUserByLogin(string login);

        User? GetUserById(int id);
    }
}
