using System.ComponentModel.DataAnnotations;

public class GetProduct : ProductBase
{
    [Required]
    public int Id { get; set; }
    public GetCategory? Category { get; set; }
}