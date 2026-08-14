public class CategoryServices(IGeneric<Category> categoryInterface) : ICategoryServices
{
    public async Task<ServicesResponse> CreateAsync(CreateCategory Category)
    {
        Category CategoryEntity = Category.CategoryToEntityMapper();
        var result = await categoryInterface.CreateAsync(CategoryEntity);
        return result > 0 ? new ServicesResponse(true, "Category created successfully")
        : new ServicesResponse(false, "Category not Added");
    }

    public async Task<ServicesResponse> DeleteAsync(int id)
    {
        var result = await categoryInterface.DeleteAsync(id);
        return result > 0 ? new ServicesResponse(true, "Category deleted successfully")
        : new ServicesResponse(false, "Category not deleted");
    }

    public async Task<IEnumerable<GetCategory>> GetAllAsync()
    {
        var categories = await categoryInterface.GetAllAsync();
        if (!categories.Any())
        {
            return [];
        }
        return categories.Select(category => category.CategoryToGetCategoryMapper());
    }

    public async Task<GetCategory> GetByIdAsync(int id)
    {
        var categories = await categoryInterface.GetByIdAsync(id);
        if (categories == null)
        {
            throw new ItemNotFoundException($"item with  {id} is not found");

        }
        return categories.CategoryToGetCategoryMapper();
    }

    public async Task<ServicesResponse> UpdateAsync(UpdateCategory Category)
    {
        Category CategoryEntity = Category.CategoryToEntityMapper();
        var result = await categoryInterface.UpdateAsync(CategoryEntity);
        return result > 0 ? new ServicesResponse(true, "Category updated successfully")
            : new ServicesResponse(false, "Category not updated");
    }

}



