using System.Threading.Tasks;
using AnalyticsAPI.Models;

namespace AnalyticsAPI.Services
{
    public interface IEventService
    {
        GenericResponse<ActionResponse> GetMostFrequentAction();
        GenericResponse<Event> AddEventLog(ActionRequest request);
    }
}