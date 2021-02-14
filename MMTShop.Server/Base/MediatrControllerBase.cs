using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MMTShop.Shared.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMTShop.Server.Base
{
    [ApiController, Route("[controller]")]
    public class MediatrControllerBase 
        : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();

        public async Task<IActionResult> SendAsync(
            object request, 
            CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

             var response = await Mediator
                    .Send(request, cancellationToken);

            if(response is ResponseBase responseBase)
            {
                if (responseBase.Errors !=null 
                    && responseBase.Errors.Any())
                {
                    return BadRequest(responseBase.Errors);
                }
            }

            return Ok(response);
        }

        protected IActionResult BadRequest(
            IEnumerable<ValidationFailure> validationFailures)
        {
            foreach(var validationFailure in validationFailures)
            {
                ModelState
                    .AddModelError(
                        validationFailure.PropertyName, 
                        validationFailure.ErrorMessage);
            }

            return BadRequest(ModelState);
        }

    }
}
