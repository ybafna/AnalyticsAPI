using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsAPI.Context;
using AnalyticsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsAPI.Repositories
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly AppDbContext appDbContext;
        public InteractionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AddInteraction(int UserId, int EventId)
        {

            //Find the User and Event entity that is already being tracked
            var User = appDbContext.Users.Find(UserId);
            var Event = appDbContext.Events.Find(EventId);

            //Create new interaction
            UserEventInteraction Interaction = new UserEventInteraction();
            Interaction.User = User;
            Interaction.Event = Event;
            var result = appDbContext.Interactions.Add(Interaction);
            // appDbContext.SaveChanges();
            if (appDbContext.SaveChanges() != 1)
            {
                appDbContext.Events.Remove(Event);

                List<UserEventInteraction> interactionsList = appDbContext.Interactions.Where(u => u.User.UserId == UserId).ToList();
                if (interactionsList.Count == 1)
                    appDbContext.Users.Remove(User);

                //TO-DO : Check how to delete the user
            }
        }

    }
}