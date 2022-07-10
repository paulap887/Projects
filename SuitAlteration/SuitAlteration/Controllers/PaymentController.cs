using Microsoft.AspNetCore.Mvc;
using SuitAlteration.Application.Alterations.Commands;
using SuitAlteration.Application.Alterations_Payment;

namespace SuitAlteration.API.Controllers
{
    public class PaymentController : ApiControllerBase
    {
     
        /// <summary>
        ///  Process Payment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("RecordPayment")]
        public async Task<ActionResult<int>> RecordPayment(CollectPaymentCommand command) 
        {
            return await Mediator.Send(command);
        }

    }
}
