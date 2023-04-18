using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShapeShifters.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ShapeShifters.Controllers;

public class ExerciseController : Controller 
{

    private MyContext db;  // or use _context instead of db (Make sure this matches on all controller files)
    
    public ExerciseController(MyContext context)
    {
        db = context; // if you use _context above use it here too (Make sure this matches on all controller files)
    }
    private int? uid {
        get {
            return HttpContext.Session.GetInt32("uid");
        }
    }
    
    // Recommend routeName and FunctionName be the same
    
    [HttpGet("/exercises")]
    public IActionResult ExerciseList() {
        return View("ExerciseList");
    }

    [HttpGet("/exercises/{item}")]
    public IActionResult BodyPart() {
        return View("ExerciseByBodyPart");
    }

    [HttpGet("/exercises/{item}/{id:int}")]
    public IActionResult OneExercise() {
        return View("OneExercise");
    }
    
    
}