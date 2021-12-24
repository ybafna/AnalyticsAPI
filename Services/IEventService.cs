using System.Threading.Tasks;
using AnalyticsAPI.Models;

namespace AnalyticsAPI.Services
{
    public interface IEventService
    {
        GenericResponse<ActionResponse> GetMostFrequentAction();
        GenericResponse<UserEventInteraction> AddEventLog(ActionRequest request);
    }
}