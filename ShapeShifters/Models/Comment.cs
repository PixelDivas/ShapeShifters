#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ShapeShifters.Models;

public class Comment {
    [Key]
    public int CommentId {get; set;}
    // add more attributes here

    [Required]
    public string Content {get;set;}

    //! 1 user can make many comments. (User model needed)
    public int UserId{get;set;}
    public User? CommentAuthor {get;set;}

    //! Each comment belongs to one post
    public int PostId {get;set;}
    public Post? OriginalPost {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}