#pragma warning disable CS8618
namespace ShapeShifters.Models;

public class ViewModel 
{
    public List<Post> allPosts { get; set; } = new List<Post>();
    public Comment comment { get; set; }
}