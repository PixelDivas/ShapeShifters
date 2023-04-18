#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ShapeShifters.Models;
public class FileUpload
{
    [Key]
    public int FileId { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] FileData { get; set; }
    public int PostId {get;set;}
    public Post? OwnerPost {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
