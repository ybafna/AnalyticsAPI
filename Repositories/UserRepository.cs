using System.Linq;
using System.Threading.Tasks;
using AnalyticsAPI.Context;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //Adds a new user to DB Context
        public int AddUser(User User)
        {
            var result = appDbContext.Users.Add(User);
            appDbContext.SaveChanges();
            return User.UserId;
        }


        //Fetches the user from DB using user id
        public User GetUser(int UserId)
        {
            var result = appDbContext.Users.FirstOrDefault(u => u.UserId == UserId);
            return result;
        }

    }
}