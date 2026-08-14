public class ProductServices(IGeneric<Product> productInterface) : IProductServices
{
    public async Task<ServicesResponse> CreateAsync(CreateProduct product)
    {
        Product productEntity = product.ProductToEntityMapper();
        var result = await productInterface.CreateAsync(productEntity);
        return result > 0 ? new ServicesResponse(true, "Product created successfully")
        : new ServicesResponse(false, "Product not Added");
    }


    public async Task<ServicesResponse> DeleteAsync(int id)
    {
        var result = await productInterface.DeleteAsync(id);
        return result > 0 ? new ServicesResponse(true, "Product deleted successfully")
        : new ServicesResponse(false, "Product not deleted");
    }

    public async Task<IEnumerable<GetProduct>> GetAllAsync()
    {
        var products = await productInterface.GetAllAsync();
        if (!products.Any())
        {
            return [];
        }
        return products.Select(product => product.ProductToGetProductMapper());


    }

    public async Task<GetProduct> GetByIdAsync(int id)
    {
        var products = await productInterface.GetByIdAsync(id);
        if (products == null)
        {
            throw new ItemNotFoundException($"item with  {id} is not found");

        }
        return products.ProductToGetProductMapper();
    }

    public async Task<ServicesResponse> UpdateAsync(UpdateProduct product)
    {
        Product productEntity = product.ProductToEntityMapper();
        var result = await productInterface.UpdateAsync(productEntity);
        return result > 0 ? new ServicesResponse(true, "Product updated successfully")
            : new ServicesResponse(false, "Product not updated");
    }
}