using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsAPI.Models
{
    [Serializable()]
    public class ErrorMessages
    {
        public const string ERROR_RETRIEVING_DATA = "Could not retreive data from the server. Please check logs for more information.";
        public const string ERROR_NO_DATA = "No Data Available. Please add some data in order to see the statistics.";
        public const string ERROR_ADDING_DATA = "Unexpected issue while adding the data. Please check logs for more information.";

    }
}