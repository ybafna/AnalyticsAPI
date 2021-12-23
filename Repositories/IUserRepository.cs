using System.Threading.Tasks;
using AnalyticsAPI.Models;

namespace AnalyticsAPI.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User User);
        User GetUser(int UserId);
    }

}