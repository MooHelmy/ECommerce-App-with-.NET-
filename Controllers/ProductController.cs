using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
[Authorize]
public class ProductController(IProductServices productServices) : ControllerBase
{
    [HttpGet("All")]
    [AllowAnonymous]
    public async Task<ActionResult> GetAllAsync()
    {
        var products = await productServices.GetAllAsync();
        return products.Any() ? Ok(products) : NotFound(products);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var product = await productServices.GetByIdAsync(id);
        return product == null ? NotFound(product) : Ok(product);
    }

    [HttpPost("Add")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<ActionResult> CreateAsync(CreateProduct product)
    {
        var result = await productServices.CreateAsync(product);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<ActionResult> UpdateAsync(UpdateProduct product)
    {
        var result = await productServices.UpdateAsync(product);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("Delete/{id}")]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await productServices.DeleteAsync(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}