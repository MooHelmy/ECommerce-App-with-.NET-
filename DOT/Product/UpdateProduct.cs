using System.ComponentModel.DataAnnotations;

public class UpdateProduct : ProductBase
{
    [Required]
    public int Id { get; set; }
}
