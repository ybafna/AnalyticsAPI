using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class ActionResponse
    {
        public int MaxFrequency { get; set; }
        public EventType ActionWithMaxFrequency { get; set; }
        public List<ActionFrequencyPerUser> frequencyPerUser { get; set; }

    }
}