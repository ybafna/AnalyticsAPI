using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

    }
}