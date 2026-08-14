public class CategoryServices(IGeneric<Category> categoryInterface) : ICategoryServices
{
    public async Task<ServicesResponse> CreateAsync(CreateCategory category)
    {
        Category categoryEntity = category.CategoryToEntityMapper();
        var result = await categoryInterface.CreateAsync(categoryEntity);
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
        var categories = await categoryInterface.GetAllAsync(c => c.Products);   // ✅ إضافة Include
        if (!categories.Any())
        {
            return [];
        }
        return categories.Select(category => category.CategoryToGetCategoryMapper());
    }

    public async Task<GetCategory> GetByIdAsync(int id)
    {
        var category = await categoryInterface.GetByIdAsync(id, c => c.Products);   // ✅ إضافة Include
        return category.CategoryToGetCategoryMapper();
    }

    public async Task<ServicesResponse> UpdateAsync(UpdateCategory category)
    {
        var existingCategory = await categoryInterface.GetByIdAsync(category.Id);
        if (existingCategory == null)
        {
            return new ServicesResponse(false, "Category not found");
        }

        var updatedCategory = category.ApplyUpdateTo(existingCategory);

        var result = await categoryInterface.UpdateAsync(updatedCategory);
        return result > 0 ? new ServicesResponse(true, "Category updated successfully")
            : new ServicesResponse(false, "Category not updated");
    }
}