#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ShapeShifters.Models;

public class Image {
    [Key]
    public int ImageId {get; set;}
    public string imgUrl { get; set; }

    //many to one relatonship to posts
    public int PostId { get; set; }
    public Post? OwnerPost { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}