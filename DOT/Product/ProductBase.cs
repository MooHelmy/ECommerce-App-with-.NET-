using System.ComponentModel.DataAnnotations;

public class ProductBase
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }

    public decimal Price { get; set; }
    [Required]
    public string? Base64Image { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

}