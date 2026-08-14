using System.ComponentModel.DataAnnotations;

public class ProductBase
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string? Base64Image { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int CategoryId { get; set; }

}