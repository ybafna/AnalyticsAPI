using System.Threading.Tasks;
using AnalyticsAPI.Models;

namespace AnalyticsAPI.Repositories
{
    public interface IInteractionRepository
    {
        UserEventInteraction AddInteraction(int UserId, int EventId);
    }

}