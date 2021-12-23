using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models{
    [Serializable()]
    public class GenericResponse<T>
    {
        public T Data {get; set;}
        
        public GenericErrorResponse Error {get; set;}
        
    }
}