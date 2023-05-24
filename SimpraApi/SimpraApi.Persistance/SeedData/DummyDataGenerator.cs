using Bogus;
using Bogus.Extensions;

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
            .RuleFor(x => x.Name, f => f.Commerce.Categories(1)[0].ClampLength(max: 30));

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

        return new Dictionary<string, IEnumerable<object>>()
        {
            {"Category",categories },
            {"Product",products }
        };
    }
}
