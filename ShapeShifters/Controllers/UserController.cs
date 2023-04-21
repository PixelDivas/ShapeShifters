

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShapeShifters.Models;
using Microsoft.AspNetCore.Identity;//this help hash the password in the database
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShapeShifters.Controllers;

public class UserController : Controller 
{

    private MyContext db;  
    public UserController(MyContext context)
    {
        db = context; 
    }
    private int? uid {
        get {
            return HttpContext.Session.GetInt32("uid");
        }
    }
    
    
    
    [HttpGet("")]
    public IActionResult Index() {
        if(HttpContext.Session.GetInt32("uid") != null) 
        {
            return RedirectToAction("ExerciseHome", "Exercise");
        } else {
            return View("index");
        }
    }

      [HttpGet("/login")]
    public IActionResult Login() {
        if(HttpContext.Session.GetInt32("uid") != null) 
        {
            return RedirectToAction("ExerciseHome", "Exercise");
        } else {
            return View("Login");
        }
    }


   
    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
          //Make the email unique , you cannot register with the same email
        if (ModelState.IsValid)
        {
            if (db.Users.Any(User => User.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }
        if (ModelState.IsValid == false)
        {
            return View("Index");
        }
           
               
         else 
       {
            PasswordHasher<User> hash = new PasswordHasher<User>(); 
            newUser.Password = hash.HashPassword(newUser, newUser.Password);
            // let newUser.Password equal a hashed version of the password
            db.Users.Add(newUser);
            db.SaveChanges();

         
            HttpContext.Session.SetInt32("uid", newUser.UserId);
            HttpContext.Session.SetString("name", newUser.UserName );
            return RedirectToAction("ExerciseHome", "Exercise");
        }
    }


    [HttpPost("/login")]
    public IActionResult Login(LoginUser getUser) {
        if(!ModelState.IsValid) {
            return View("Login");} 

        else
        {
            User? userInDb = db.Users.FirstOrDefault(u => u.Email == getUser.LoginEmail);

            
            if(userInDb == null) 
            {
                

                ModelState.AddModelError("LoginEmail", "Invalid Email");
                return View("Login");

            } 
            
            else 
            {    PasswordHasher<LoginUser> hash = new PasswordHasher<LoginUser>();

                var result = hash.VerifyHashedPassword(getUser, userInDb.Password, getUser.LoginPassword);

                
                if(result == 0)  
                { 
                    ModelState.AddModelError("LoginPassword", "Invalid Password");
                    return View("Login");}
                 else 
                {
                    HttpContext.Session.SetInt32("uid", userInDb.UserId);
                    HttpContext.Session.SetString("name", userInDb.UserName );
                    return RedirectToAction("ExerciseHome", "Exercise");
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

    

   public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Find the session, but remember it may be null so we need int?
            int? userId = context.HttpContext.Session.GetInt32("uid");
            
            if (userId == null)
            {
                
               
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
        }
    }



}


    
     