using Microsoft.AspNetCore.Mvc;

public class CategoryControllee(CategoryServices categoryServices) : ControllerBase
{
    [HttpGet("All")]

    public async Task<ActionResult> GetAllAsync()
    {
        var categorys = await categoryServices.GetAllAsync();
        return categorys.Any() ? Ok(categorys) : NotFound(categorys);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var category = await categoryServices.GetByIdAsync(id);
        return category == null ? NotFound(category) : Ok(category);
    }

    [HttpPost("Add")]
    public async Task<ActionResult> CreateAsync(CreateCategory category)
    {
        var result = await categoryServices.CreateAsync(category);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("Update")]
    public async Task<ActionResult> UpdateAsync(UpdateCategory category)
    {
        var result = await categoryServices.UpdateAsync(category);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete(" Delete/{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await categoryServices.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }


}