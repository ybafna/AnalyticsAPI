using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsAPI.Context;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext appDbContext;

        public EventRepository(AppDbContext _appDbContext)
        {
            this.appDbContext = _appDbContext;
        }

        public int AddEvent(Event Event)
        {
            var result = appDbContext.Events.Add(Event);
            appDbContext.SaveChanges();
            return Event.EventId;
        }

        public MostFrequentActionResponse GetMostFrequentAction()
        {
            var result = appDbContext.Events.GroupBy(e => e.EventType)
                        .Select(e => new { EventType = e.Key, Count = e.Count() })
                        .OrderByDescending(x => x.Count)
                        .FirstOrDefault();

            MostFrequentActionResponse Response = null;

            if (result != null)
            {
                Response = new MostFrequentActionResponse();
                Response.MaxFrequency = result.Count;
                Response.ActionWithMaxFrequency = result.EventType;
            }
            return Response;
        }
        public List<ActionFrequencyPerUser> GetMostFrequentActionPerUser(EventType EventType)
        {
            List<ActionFrequencyPerUser> result = appDbContext.Events.Join(appDbContext.Interactions,
                            e => e.EventId,
                            i => i.Event.EventId,
                            (e, i) => new
                            {
                                EventType = e.EventType,
                                UserId = i.User.UserId
                            }).Where(x => x.EventType == EventType)
                            .GroupBy(x => x.UserId)
                            .Select(e => new ActionFrequencyPerUser(e.Key, e.Count()))
                            .ToList();

            return result;
        }

    }
}