using System.Threading.Tasks;
using AnalyticsAPI.Models;

namespace AnalyticsAPI.Repositories
{
    public interface IInteractionRepository
    {
        void AddInteraction(int UserId, int EventId);
    }

}