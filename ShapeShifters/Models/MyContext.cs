#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace ShapeShifters.Models;

public class MyContext : DbContext 
{    
    public MyContext(DbContextOptions options) : base(options) { }    

   //replace classname with name of model file
    
    public DbSet<User> Users { get; set; }
}
