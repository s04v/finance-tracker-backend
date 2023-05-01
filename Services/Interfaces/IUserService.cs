using FinanceTracker.Models;

namespace FinanceTracker.Services.Interfaces
{
    public interface IUserService
    {
        User GetOne();

        User? Create(User user);

        string Login(User user);
    }
}
