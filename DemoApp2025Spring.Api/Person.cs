using System.ComponentModel.DataAnnotations;

namespace DemoApp2025Spring.Api;

public class Person
{
    [Required]
    public string Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Range(typeof(DateOnly), "1990-01-01", "2000-12-31")]
    public DateOnly? BirthDate { get; set; }
}