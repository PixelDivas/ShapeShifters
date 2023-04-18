#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ShapeShifters.Models;

public class MyContext : DbContext 
{    
    public MyContext(DbContextOptions options) : base(options) { }    

   //replace classname with name of model file
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts {get;set;}
    public DbSet<Comment> Comments {get;set;}
    public DbSet<Image> Images {get;set;}
}
