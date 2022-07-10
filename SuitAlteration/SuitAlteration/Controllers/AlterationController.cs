using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuitAlteration.Application.Alterations.Commands;
using SuitAlteration.Application.Alterations.Commands.FinishAlteration;
using SuitAlteration.Application.Alterations.Queries;
using SuitAlteration.Application.Common.Models;
using SuitAlteration.Domain.Entities;

namespace SuitAlteration.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AlterationController : ApiControllerBase
    {
        /// <summary>
        ///  Create New Alteration
        /// </summary>
        /// <param name="command">Model to create a new Alteration</param>
        /// <returns>Returns the created Alteration</returns>
        /// <response code="200">Returned if the Alteration was created</response>
        /// <response code="400">Returned if the model couldn't be parsed or saved</response>
        /// <response code="422">Returned when the validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<int>> Alteration(CreateNewAlterationCommand command)
        {
            return await Mediator.Send(command); 
        }

        /// <summary>
        ///  Start Alteration
        /// </summary>
        /// <param name="command">Model to start Alteration</param>
        /// <returns>Returns the started Alteration Id</returns>
        /// <response code="200">Returned Alteration Id</response>
        /// <response code="400">Returned when the validation failed</response> 
        /// <response code="422">Returned when the domain validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("Start")]
        public async Task<ActionResult<int>> StartAlteration(StartPaidAlterationCommand command)
        {
            return await Mediator.Send(command);
        }


        /// <summary>
        ///  To Record once Alteration finished
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Returns the started Alteration Id</returns> 
        /// <response code="200">Returned Alteration Id</response>
        /// <response code="400">Returned when the validation failed</response> 
        /// <response code="422">Returned when the domain validation failed</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("Finish")]
        public async Task<ActionResult<int>> FinishAlteration(FinishAlterationCommand command)
        {
            return await Mediator.Send(command);
        }


        /// <summary>
        ///   Action to retrieve all alterations by particular status
        /// </summary>
        /// <returns>Returns a list of all alterations or an empty list, if there is no alterations</returns>
        /// <response code="200">Returned if the list of alterations was retrieved</response>
        /// <response code="400">Returned if the alterations could not be retrieved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<PaginatedList<AlterationDto>>> Alterations([FromQuery] GetAlterationsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
