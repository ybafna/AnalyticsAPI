using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class MostFrequentActionResponse
    {

        public EventType ActionWithMaxFrequency { get; set; }
        public int MaxFrequency { get; set; }
        public MostFrequentActionResponse(EventType ActionWithMaxFrequency, int MaxFrequency)
        {
            this.ActionWithMaxFrequency = ActionWithMaxFrequency;
            this.MaxFrequency = MaxFrequency;
        }

    }
}