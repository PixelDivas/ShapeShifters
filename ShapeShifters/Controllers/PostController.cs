using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShapeShifters.Models;

namespace ShapeShifters.Controllers;

public class PostController : Controller
{
    private MyContext db;

    private int? uid {
        get {
            return HttpContext.Session.GetInt32("uid");
        }
    }
    public PostController(MyContext context){
        db = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New(){
        return View("New");
    }

    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost){
        if(!ModelState.IsValid){
            
            return View("New");
        }

        newPost.UserId = (int)uid;
        db.Posts.Add(newPost);
        db.SaveChanges();
        return RedirectToAction("File", new{ postId = newPost.PostId} );
    }

    [HttpGet("/posts/all")]
    public IActionResult All(){

        List<Post> allPosts = db.Posts.Include(p => p.MessageAuthor).Include(p => p.FileUploadList).ToList();
        return View("All", allPosts);
    }

    [HttpGet("/posts/{postId}/edit")]
    public IActionResult Edit(int postId){
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == postId);
        if(post is null || post.UserId != uid){
            return RedirectToAction("All");
        } 
        return View("Edit", post);
    }

    [HttpPost("/posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId){
        if(!ModelState.IsValid){
            return Edit(postId);
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == postId);
        post.Title = editedPost.Title;
        post.PostContent = editedPost.PostContent;
        post.UpdatedAt = DateTime.Now;
        db.Posts.Update(post);
        db.SaveChanges();
        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postId}/delete")]
    public IActionResult Delete(int postId){
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == postId);
        if(post is not null && post.UserId == uid){
            db.Posts.Remove(post);
            db.SaveChanges();
        } 
        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postId}/file")]
    public IActionResult File(int postId){
        Post? post = db.Posts.Include(p => p.FileUploadList).FirstOrDefault(p => p.PostId == postId);
        if(post is null || post.UserId != uid){
            return RedirectToAction("All");
        } 
        return View("File", post);
    }

    [HttpPost("/posts/{postId}/upload")]
    public async Task<IActionResult> Upload(IFormFile file, int postId){
        if (file != null && file.Length > 0)
    {
        var fileUpload = new FileUpload
        {
            FileName = file.FileName,
            FileType = file.ContentType,
            PostId = postId
        };
        
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            fileUpload.FileData = memoryStream.ToArray();
        }
        
        // Save file upload data to database
        db.FileUploads.Add(fileUpload);
        await db.SaveChangesAsync();
    }
    return File(postId);
    }

    [HttpGet("/all/files")]
    public IActionResult AllFiles(){
        List<FileUpload> allFiles = db.FileUploads.ToList();
        return View("AllFiles", allFiles);
    }
}                  