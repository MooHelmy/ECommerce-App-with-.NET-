public interface IProductServices
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct> GetByIdAsync(int id);
    Task<ServicesResponse> CreateAsync(CreateProduct product);
    Task<ServicesResponse> UpdateAsync(UpdateProduct product);
    Task<ServicesResponse> DeleteAsync(int id);
}
