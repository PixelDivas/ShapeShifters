#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ShapeShifters.Models;

public class Post {
    [Key]
    public int PostId {get; set;}
    
    [Required(ErrorMessage = "is required!")]
    public string Title { get; set; }

    [Required(ErrorMessage = "is required!")]
    public string PostContent {get;set;}
    
    //! 1 user can make many posts. (User model needed)
    public int UserId {get;set;}
    public User? MessageAuthor {get;set;}

    //! 1 post can have many comments.
    public List<Comment> CommentList {get;set;}= new List<Comment> ();

    //one-to-many relationship to images
    public List<Image> ImageList { get; set; } = new List<Image>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}