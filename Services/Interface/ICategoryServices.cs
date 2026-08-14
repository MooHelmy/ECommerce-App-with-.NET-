public interface ICategoryServices
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct> GetByIdAsync(int id);
    Task<ServicesResponse> CreateAsync(CreateCategory Category);
    Task<ServicesResponse> UpdateAsync(UpdateProduct Category);
    Task<ServicesResponse> DeleteAsync(int id);
}