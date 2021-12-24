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

        public EventRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Event AddEvent(Event Event, int UserId)
        {
            var User = appDbContext.Users.Find(UserId);
            Event.User = User;
            var result = appDbContext.Events.Add(Event);
            appDbContext.SaveChanges();
            return Event;
        }

        public MostFrequentActionResponse GetMostFrequentAction()
        {
            MostFrequentActionResponse response = appDbContext.Events.GroupBy(e => e.EventType)
                        .Select(e => new { EventType = e.Key, Count = e.Count() })
                        .OrderByDescending(x => x.Count)
                        .Select(e => new MostFrequentActionResponse(e.EventType, e.Count))
                        .FirstOrDefault();

            return response;
        }
        public List<ActionFrequencyPerUser> GetMostFrequentActionPerUser(EventType EventType)
        {
            List<ActionFrequencyPerUser> response = appDbContext.Events
                            .Where(x => x.EventType == EventType)
                            .GroupBy(x => x.User.UserId)
                            .Select(e => new ActionFrequencyPerUser(e.Key, e.Count()))
                            .ToList();

            return response;
        }

    }
}