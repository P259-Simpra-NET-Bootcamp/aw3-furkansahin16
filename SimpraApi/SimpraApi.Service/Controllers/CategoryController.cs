using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpraApi.Service.Controllers;

public class CategoryController : BaseApiController
{
    public CategoryController(IMediator mediator) : base(mediator) { }
    [HttpGet]
    public async Task<IResponse> GetAll() => await Mediator.Send(new GetAllCategoryQueryRequest());

    [HttpGet("{Id}")]
    public async Task<IResponse> GetById(GetByIdCategoryQueryRequest request) => await Mediator.Send(request);

    [HttpGet]
    public async Task<IResponse> GetWhere([FromQuery] GetWhereCategoryQueryRequest request) => await Mediator.Send(request);

    [HttpPost]
    public async Task<IResponse> Create(CreateCategoryCommandRequest request) => await Mediator.Send(request);

    [HttpPut]
    public async Task<IResponse> Update(UpdateCategoryCommandRequest request) => await Mediator.Send(request);

    [HttpDelete("{Id}")]
    public async Task<IResponse> Update(DeleteCategoryCommandRequest request) => await Mediator.Send(request);
}
