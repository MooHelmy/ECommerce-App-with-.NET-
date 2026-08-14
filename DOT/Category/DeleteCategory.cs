using System.ComponentModel.DataAnnotations;

public class DeleteCategory : CategoryBase
{
    [Required]
    public int Id { get; set; }
}
