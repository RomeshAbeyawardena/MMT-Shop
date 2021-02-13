﻿using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMTShop.Server.Base
{
    [ApiController, Route("[controller]")]
    public class MediatrControllerBase : ControllerBase
    {
        public IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();

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
                if (responseBase.Errors !=null && responseBase.Errors.Any())
                {
                    return BadRequest(responseBase.Errors);
                }
            }

            return Ok(response);
        }

    }
}
