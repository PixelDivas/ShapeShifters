

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShapeShifters.Models;
using Microsoft.AspNetCore.Identity;//this help hash the password in the database

namespace ShapeShifters.Controllers;

public class UserController : Controller 
{

    private MyContext db;  
    public UserController(MyContext context)
    {
        db = context; 
    }
    
    
    
    [HttpGet("")]
    public IActionResult Index() {
        if(HttpContext.Session.GetInt32("uid") != null) 
        {
            return RedirectToAction("Dashboard", "food");
        } else {
            return View("Index");
        }
    }

   
    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
          
         if(!ModelState.IsValid) { return View("Index");}
           
               
         else 
       {
            PasswordHasher<User> hash = new PasswordHasher<User>(); 
            newUser.Password = hash.HashPassword(newUser, newUser.Password);
            // let newUser.Password equal a hashed version of the password
            db.Users.Add(newUser);
            db.SaveChanges();

         
            HttpContext.Session.SetInt32("uid", newUser.UserId);
            HttpContext.Session.SetString("name", newUser.UserName );
            return RedirectToAction("Dashboard", "food");
        }
    }

  
    [HttpPost("/login")]
    public IActionResult Login(LoginUser getUser) {
        if(!ModelState.IsValid) {
            return View("Index");} 

        else
        {
            User? userInDb = db.Users.FirstOrDefault(u => u.Email == getUser.LoginEmail);

            
            if(userInDb == null) 
            {
                

                ModelState.AddModelError("LoginEmail", "Invalid Email");
                return View("Index");

            } 
            
            else 
            {    PasswordHasher<LoginUser> hash = new PasswordHasher<LoginUser>();

                var result = hash.VerifyHashedPassword(getUser, userInDb.Password, getUser.LoginPassword);

                
                if(result == 0)  
                { 
                    ModelState.AddModelError("LoginPassword", "Invalid Password");
                    return View("Index");}
                 else 
                {
                    HttpContext.Session.SetInt32("uid", userInDb.UserId);
                    HttpContext.Session.SetString("name", userInDb.UserName );
                    return RedirectToAction("Dashboard", "food");
                }
            }   
        }
    }


    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    





}


    
     