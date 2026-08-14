public static class ExtensionMethod
{
    public static Product ProductToEntityMapper(this CreateProduct product)
    {
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId
        };
    }
    public static Product ProductToEntityMapper(this UpdateProduct product)
    {
        return new Product
        {
            Id = product.Id,           // مهم هنا الـ Id عشان تعرف تحدث الـ record الصح
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId
        };
    }
    public static GetProduct ProductToGetProductMapper(this Product product)
    {
        return new GetProduct
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Quantity = product.Quantity,
            Category = new GetCategory
            {
                Id = product.CategoryId,
                Name = product.Category?.Name,
                Products = new List<GetProduct>()
            }
        };
    }

} // public static async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(this IGeneric<TEntity> genericInterface) where TEntity : class