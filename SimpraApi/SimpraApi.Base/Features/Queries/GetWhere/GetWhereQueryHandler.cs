using System.Linq.Expressions;

namespace SimpraApi.Base;
public abstract class GetWhereQueryHandler<TEntity, TRequest, TResponse> :
    EntityHandler<TEntity>,
    IRequestHandler<TRequest, IResult>
    where TEntity : BaseEntity
    where TRequest : GetWhereQueryRequest
    where TResponse : EntityResponse
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    public GetWhereQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }
    public GetWhereQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, Expression<Func<TEntity, object>>[] includes) : base(unitOfWork, includes)
    {
        this._repository = base._unitOfWork.GetRepository<TEntity>();
        _mapper = mapper;
    }

    public async virtual Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var expression = GetExpression(request);
        var entites = expression is null ?
            await _repository.GetAllAsync(false, Includes) :
            await _repository.GetAllAsync(expression, false, Includes);

        return entites.Any()
            ? new SuccessDataResult<EntityResponse>(_mapper.Map<List<TResponse>>(entites), Messages.ListSuccess.Format(nameof(TEntity)), HttpStatusCode.OK)
            : new ErrorResult(Messages.ListError.Format(nameof(TEntity)), HttpStatusCode.NoContent);
    }

    protected Expression<Func<TEntity, bool>>? GetExpression(TRequest request)
    {
        var expressions = new List<Expression<Func<TEntity, bool>>>();
        var filters = request.GetType().GetProperties();

        foreach (var filter in filters)
        {
            var value = filter.GetValue(request);
            if (value is not null)
            {
                var parameter = Expression.Parameter(typeof(TEntity));
                var propertyAccess = Expression.Property(parameter, filter.Name);
                var filterValue = Expression.Constant(value!.ToString()!.Trim().ToLower());
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsExpression = Expression.Call(propertyAccess, containsMethod!, filterValue);
                var expression = Expression.Lambda<Func<TEntity, bool>>(containsExpression, parameter);

                expressions.Add(expression);
            }
        }

        var finalExpression = expressions.Aggregate((Expression<Func<TEntity, bool>>)null, (current, expression) =>
        {
            if (current == null) return expression;
            var invoked = Expression.Invoke(expression, current.Parameters);
            return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(current.Body, invoked), current.Parameters);
        });

        return finalExpression;
    }
}
