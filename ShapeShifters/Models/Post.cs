#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ShapeShifters.Models;

public class Post {
    [Key]
    public int PostId {get; set;}
    

    public string PostContent {get;set;}
    
    //! 1 user can make many posts. (User model needed)
    public int UserId {get;set;}
    public User? MessageAuthor {get;set;}

    //! 1 post can have many comments.
    public List<Comment> CommentList {get;set;}= new List<Comment> ();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}