using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public EventType EventType { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventData { get; set; }

        public User User {get; set;}
    }
}