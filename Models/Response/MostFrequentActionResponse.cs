using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class MostFrequentActionResponse
    {
        public EventType ActionWithMaxFrequency { get; set; }
        public int MaxFrequency { get; set; }

    }
}