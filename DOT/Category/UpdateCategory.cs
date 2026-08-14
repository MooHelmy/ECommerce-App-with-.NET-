using System.ComponentModel.DataAnnotations;

public class UpdateCategory : CategoryBase
{
    [Required]
    public int Id { get; set; }
}
