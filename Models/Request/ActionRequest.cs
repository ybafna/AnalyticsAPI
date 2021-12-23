using System;
using System.ComponentModel.DataAnnotations;
namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class ActionRequest
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EnumDataType(typeof(EventType), ErrorMessage = "Incorrect Event Type")]
        public EventType EventType { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string EventData { get; set; }
    }
}