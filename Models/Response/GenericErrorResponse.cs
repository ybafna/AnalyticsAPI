using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models{
    [Serializable()]
    public class GenericErrorResponse
    {
        public string ErrorMessage {get; set;}
        
    }
}