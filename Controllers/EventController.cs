using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using AnalyticsAPI.Exceptions;
using AnalyticsAPI.Models;
using AnalyticsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnalyticsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;
        private readonly ILogger<EventController> logger;

        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<ActionResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<Object>))]
        public IActionResult GetMostFrequentAction()
        {
            GenericResponse<ActionResponse> response = null;
            try
            {
                response = eventService.GetMostFrequentAction();
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new GenericResponse<ActionResponse>();
                response.Error = GetErrorResponse(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GenericResponse<Event>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<Object>))]
        public IActionResult AddEventLog(ActionRequest request)
        {
            if (request == null)
                return BadRequest();
            try
            {
                GenericResponse<Event> response = eventService.AddEventLog(request);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (CustomException e)
            {
                GenericResponse<Object> response = new GenericResponse<Object>();
                response.Error = GetErrorResponse(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        private GenericErrorResponse GetErrorResponse(String errorMessage)
        {
            GenericErrorResponse errorResponse = new GenericErrorResponse();
            errorResponse.ErrorMessage = errorMessage;
            return errorResponse;
        }
    }


}