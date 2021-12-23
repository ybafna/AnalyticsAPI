using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class ActionResponse
    {
        public EventType ActionWithMaxFrequency { get; set; }
        public int MaxFrequency { get; set; }

        public List<ActionFrequencyPerUser> frequenciesPerUser { get; set; }

    }
}