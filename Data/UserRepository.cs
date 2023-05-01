using FinanceTracker.Data.Interfaces;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace FinanceTracker.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public User Create(User user)
        {
            this._context.Add(user);
            this._context.SaveChanges();
            
            return user;
        }

        public bool CheckIfUserExist(User user)
        {
            return this._context.Users.FirstOrDefault(u => u.Login == user.Login) != null ? true : false;
        }

        public User? GetUserByLogin(string login)
        {
            return this._context.Users.FirstOrDefault(u => u.Login == login);
        }

        public User? GetUserById(int id)
        {
            return this._context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
