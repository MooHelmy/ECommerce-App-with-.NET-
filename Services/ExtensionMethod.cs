public static class ExtensionMethod
{
    public static Product ProductToEntityMapper(this CreateProduct product)
    {
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.Base64Image,
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
            ImageUrl = product.Base64Image,
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
            Base64Image = product.ImageUrl,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId,
            Category = new GetCategory
            {
                Id = product.CategoryId,
                Name = product.Category?.Name,
                Products = new List<GetProduct>()
            }
        };
    }

    // Category  Category Category ///////////////////////////////////
    public static Category CategoryToEntityMapper(this CreateCategory category)
    {
        return new Category
        {
            Name = category.Name
        };
    }

    public static Category CategoryToEntityMapper(this UpdateCategory category)
    {
        return new Category
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static GetCategory CategoryToGetCategoryMapper(this Category category)
    {
        return new GetCategory
        {
            Id = category.Id,
            Name = category.Name,
            Products = category.Products?.Select(p => p.ProductToGetProductMapper()).ToList() ?? new List<GetProduct>()
        };
    }

}