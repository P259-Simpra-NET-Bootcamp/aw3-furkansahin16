using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Service.Controllers;
[ApiController]
[Route("api/v3/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    public BaseApiController(IMediator mediator) => Mediator = mediator;
}
