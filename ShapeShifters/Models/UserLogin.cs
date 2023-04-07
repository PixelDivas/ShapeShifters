#pragma warning disable CS8618 

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped] // don't add column to database
public class LoginUser
{
    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    public string LoginEmail { get; set; }

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)] 
    public string LoginPassword { get; set; }
}