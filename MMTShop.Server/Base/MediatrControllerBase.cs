using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MMTShop.Server.Base
{
    [ApiController, Route("[controller]")]
    public class MediatrControllerBase : ControllerBase
    {
        [Inject] public IMediator Mediator { get; private set; }

        public async Task<IActionResult> SendAsync(
            object request, 
            CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }
    }
}
