public interface ICategoryServices
{
    Task<IEnumerable<GetCategory>> GetAllAsync();
    Task<GetCategory> GetByIdAsync(int id);
    Task<ServicesResponse> CreateAsync(CreateCategory Category);
    Task<ServicesResponse> UpdateAsync(UpdateCategory Category);
    Task<ServicesResponse> DeleteAsync(int id);
}