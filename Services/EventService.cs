using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using AnalyticsAPI.Exceptions;
using AnalyticsAPI.Models;
using AnalyticsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace AnalyticsAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;
        private readonly IUserRepository userRepository;
        private readonly IInteractionRepository interactionRepository;
        private readonly ILogger<EventService> logger;
        public EventService(ILogger<EventService> logger, IEventRepository eventRepository, IUserRepository userRepository, IInteractionRepository interactionRepository)
        {
            this.logger = logger;
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.interactionRepository = interactionRepository;
        }

        private User createUser(ActionRequest request){
            User User = new User();
            if(request.UserId!=0){
                User.UserId = request.UserId;
            }
            User.UserName = request.UserName;
            return User;
        }

        private Event createEvent(ActionRequest request){
            Event Event = new Event();
            Event.EventType = request.EventType;
            Event.Timestamp = request.Timestamp;
            Event.EventData = request.EventData;
            return Event;
        }
        public GenericResponse<ActionResponse> GetMostFrequentAction()
        {

            GenericResponse<ActionResponse> response = new GenericResponse<ActionResponse>();
            try
            {
                ActionResponse actionResponse = new ActionResponse();
                MostFrequentActionResponse mostFrequentAction = eventRepository.GetMostFrequentAction();
                if (mostFrequentAction != null)
                {
                    List<ActionFrequencyPerUser> actionFrequencies = eventRepository.GetMostFrequentActionPerUser(mostFrequentAction.ActionWithMaxFrequency);
                    actionResponse.frequenciesPerUser = actionFrequencies;
                    actionResponse.ActionWithMaxFrequency = mostFrequentAction.ActionWithMaxFrequency;
                    actionResponse.MaxFrequency = mostFrequentAction.MaxFrequency;
                    response.Data = actionResponse;
                }
                else
                {
                    logger.LogError("EventService :: No Data Available");
                    throw new CustomException(ErrorMessages.ERROR_RETRIEVING_DATA);
                }
            }
            catch (Exception e)
            {
                logger.LogError("EventService :: Error Retrieving Data " + e.StackTrace);
                throw new CustomException(ErrorMessages.ERROR_RETRIEVING_DATA);
            }
            return response;
        }

        public void AddEventLog(ActionRequest request)
        {
            try
            {
                int UserId = request.UserId;
                User User = null;
                if (UserId != 0)
                {
                    User = userRepository.GetUser(UserId);
                }
                if (User == null)
                {
                    User = createUser(request);
                    UserId = userRepository.AddUser(User);
                }
                
                int EventId = eventRepository.AddEvent(createEvent(request));
                interactionRepository.AddInteraction(UserId, EventId);
            }
            catch (Exception e)
            {
                logger.LogError("EventService :: Error Adding Data " + e.StackTrace);
                throw new CustomException(ErrorMessages.ERROR_ADDING_DATA);
            }
        }

        
    }
}