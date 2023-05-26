using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Service.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    public BaseApiController(IMediator mediator) => Mediator = mediator;
}
