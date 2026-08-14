using System.ComponentModel.DataAnnotations;

public class GetCategory : CategoryBase
{
    [Required]
    public int Id { get; set; }
    public ICollection<GetProduct>? Products { get; set; }
}