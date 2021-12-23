using System.Collections.Generic;
using System.Threading.Tasks;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Repositories
{
    public interface IEventRepository
    {
        int AddEvent(Event Event);
        MostFrequentActionResponse GetMostFrequentAction();
        List<ActionFrequencyPerUser> GetMostFrequentActionPerUser(EventType EventType);

    }

}