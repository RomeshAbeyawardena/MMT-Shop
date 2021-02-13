using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
            if(ModelState.IsValid)
            { 
                return Ok(await Mediator.Send(request, cancellationToken));
            }

            return BadRequest(ModelState);
        }

    }
}
