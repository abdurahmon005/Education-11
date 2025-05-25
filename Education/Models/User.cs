 
using System;
using System.ComponentModel.DataAnnotations;
namespace Education.Models;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Ism { get; set; }

    [Required]
    public string? Familiya { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

