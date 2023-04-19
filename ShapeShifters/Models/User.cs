

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;// help me not to save the confirm password display in the form in the database.
namespace ShapeShifters.Models;

public class User {
    [Key]
    public int UserId {get; set;}

    [Required(ErrorMessage="The Username is required")]
    public string UserName {get; set;}

    [Required]
    [EmailAddress] // Set the type of email ,Email must be a valid email format
    [UniqueEmail] //email must be unique to the database
    public string Email {get; set;}
    
    [Required(ErrorMessage="Password must be at least 8 characters")]
    [DataType(DataType.Password)] // auto fills input type of password (specifically when using asp)
    public string Password {get; set;}
    
    [NotMapped] // please don't add me to the database, this one too is made to not save the confirm password in the database
    [Compare("Password", ErrorMessage="Dang it passwords don't match try your luck again")]
    public string Confirm {get; set;}
    
    public List<Post> UserPosts { get; set; } = new List<Post>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now; 


      
    
   



}
//This specifiq function make the email unique so a user cannot use multiple email to login, this will help us retrieve a user by his email 
public class UniqueEmailAttribute : ValidationAttribute {
    protected override ValidationResult? IsValid(object? value, ValidationContext valContext) {
        if(value == null) { // if email input is empty
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)valContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString())) {
            return new ValidationResult("Email is in use"); // if email is in database
        } else {
            return ValidationResult.Success; // email not in database good to go
        }
    }



  
}