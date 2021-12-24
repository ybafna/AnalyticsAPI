using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Repositories
{
    public interface IEventRepository
    {
        Event AddEvent(Event Event, int UserId);
        MostFrequentActionResponse GetMostFrequentAction();
        List<ActionFrequencyPerUser> GetMostFrequentActionPerUser(EventType EventType);

    }

}