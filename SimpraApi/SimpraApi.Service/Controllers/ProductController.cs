using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Service.Controllers;

public class ProductController : BaseApiController
{
    public ProductController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IResponse> GetAll() => await Mediator.Send(new GetAllProductQueryRequest());

    [HttpGet("{Id}")]
    public async Task<IResponse> GetById([FromRoute] GetByIdProductQueryRequest request) => await Mediator.Send(request);

    [HttpGet("search")]
    public async Task<IResponse> GetWhere([FromQuery] GetWhereProductQueryRequest request) => await Mediator.Send(request);

    [HttpPost]
    public async Task<IResponse> Create(CreateProductCommandRequest request) => await Mediator.Send(request);

    [HttpPut]
    public async Task<IResponse> Update(UpdateProductCommandRequest request) => await Mediator.Send(request);

    [HttpDelete("{Id}")]
    public async Task<IResponse> Update([FromRoute] DeleteProductCommandRequest request) => await Mediator.Send(request);
}
