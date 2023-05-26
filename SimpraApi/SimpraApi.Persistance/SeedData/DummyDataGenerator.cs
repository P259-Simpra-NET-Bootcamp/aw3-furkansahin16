using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpraApi.Persistance.SeedData;

public static class DummyDataGenerator
{
    public static Dictionary<string, IEnumerable<object>> GenerateDummyData(int categoryCount, int productCount)
    {
        var categoryFaker = new Faker<Category>()
            .Ignore(x => x.DeletedAt)
            .Ignore(x => x.DeletedBy)
            .Ignore(x => x.UpdatedBy)
            .Ignore(x => x.UpdatedAt)
            .RuleFor(x => x.CreatedAt, f => DateTime.UtcNow)
            .RuleFor(x => x.CreatedBy, f => "admin")
            .RuleFor(x => x.Status, f => Status.Added)
            .RuleFor(x => x.Id, f => f.IndexFaker + 1)
            .RuleFor(x => x.Name, f => f.Commerce.Categories(1)[0].ClampLength(max: 28));

        var categories = categoryFaker.Generate(categoryCount);

        var productFaker = new Faker<Product>()
            .Ignore(x => x.DeletedAt)
            .Ignore(x => x.DeletedBy)
            .Ignore(x => x.UpdatedBy)
            .Ignore(x => x.UpdatedAt)
            .RuleFor(x => x.CreatedAt, f => DateTime.UtcNow)
            .RuleFor(x => x.CreatedBy, f => "admin")
            .RuleFor(x => x.Status, f => Status.Added)
            .RuleFor(x => x.Id, f => f.IndexFaker + 1)
            .RuleFor(x => x.Name, f => f.Commerce.ProductName().ClampLength(max: 30))
            .RuleFor(x => x.Url, f => f.Internet.Url().ClampLength(max: 30))
            .RuleFor(x => x.Tag, f => f.Commerce.Ean13().ClampLength(max: 100))
            .RuleFor(x => x.CategoryId, f => categories[f.Random.Int(min: 0, max: categories.Count() - 1)].Id);

        var products = productFaker.Generate(productCount);

        categories.CorrectNameUniqueless<Category>(x => x.Name);
        products.CorrectNameUniqueless<Product>(x => x.Name);

        return new Dictionary<string, IEnumerable<object>>()
        {
            {"Category",categories },
            {"Product",products }
        };
    }

    private static void CorrectNameUniqueless<TEntity>(this IEnumerable<TEntity> data, Expression<Func<TEntity, string>> nameProperty)
    {
        var nameAccessor = nameProperty.Compile();
        var propertyInfo = (nameProperty.Body as MemberExpression)?.Member as PropertyInfo;

        var duplicates = data
            .GroupBy(nameAccessor)
            .Where(g => g.Count() > 1)
            .SelectMany(g => g)
            .ToList();

        var faker = new Faker();

        foreach (var entity in duplicates)
        {
            var originalName = nameAccessor(entity);
            var newName = originalName;

            while (data.Any(x => nameAccessor(x) == newName))
            {
                newName = typeof(TEntity).Name switch
                {
                    "Product" => newName = faker.Commerce.ProductName().ClampLength(max: 30),
                    "Category" => newName = faker.Commerce.Categories(1)[0].ClampLength(max: 30)
                };

            }
            propertyInfo?.SetValue(entity, newName);
        }
    }
}
