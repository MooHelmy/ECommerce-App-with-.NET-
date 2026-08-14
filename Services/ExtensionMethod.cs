public static class ExtensionMethod
{
    public static Product ProductToEntityMapper(this CreateProduct product)
    {
        return new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price ?? 0,
            ImageUrl = product.Base64Image,
            Quantity = product.Quantity ?? 0,
            CategoryId = product.CategoryId ?? 0
        };
    }
    public static Product ProductToEntityMapper(this UpdateProduct product)
    {
        return new Product
        {
            Id = product.Id,           // مهم هنا الـ Id عشان تعرف تحدث الـ record الصح
            Name = product.Name,
            Description = product.Description,
            Price = product.Price ?? 0,
            ImageUrl = product.Base64Image,
            Quantity = product.Quantity ?? 0,
            CategoryId = product.CategoryId ?? 0
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

    // Helpers
    public static Product ApplyUpdateTo(this UpdateProduct product, Product existingProduct)
    {
        if (product.Name != null) existingProduct.Name = product.Name;
        if (product.Description != null) existingProduct.Description = product.Description;
        if (product.Price.HasValue) existingProduct.Price = product.Price.Value;
        if (product.Base64Image != null) existingProduct.ImageUrl = product.Base64Image;
        if (product.Quantity.HasValue) existingProduct.Quantity = product.Quantity.Value;
        if (product.CategoryId.HasValue) existingProduct.CategoryId = product.CategoryId.Value;

        return existingProduct;
    }
    public static Category ApplyUpdateTo(this UpdateCategory category, Category existingCategory)
    {
        if (category.Name != null) existingCategory.Name = category.Name;

        return existingCategory;
    }

}