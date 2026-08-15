using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // لازمين لتجديد الـ Access Token بدون ما المستخدم يسجل دخول تاني
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
}