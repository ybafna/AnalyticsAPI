using System;
using System.ComponentModel.DataAnnotations;
namespace AnalyticsAPI.Models{
    [Serializable()]
    public class UserEventInteraction{
        [Key]
        public int Id {get; set;}
        [Required]
        public User User { get; set; }
        [Required]
        public Event Event { get; set; }
    }
}