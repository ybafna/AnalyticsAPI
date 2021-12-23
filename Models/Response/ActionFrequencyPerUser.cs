using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class ActionFrequencyPerUser
    {
        public int UserId { get; set; }
        public int Frequency { get; set; }

        public ActionFrequencyPerUser(int UserId, int Frequency)
        {
            this.UserId = UserId;
            this.Frequency = Frequency;
        }
    }
}