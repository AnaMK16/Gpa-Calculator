using GpaCalculator.Api.Db;
using GpaCalculator.Api.Models.Entities;
using GpaCalculator.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GpaCalculator.Api.Controllers;
[ApiController]
[Route("Student/[controller]")]
public class StudentContoller : ControllerBase
{
    private readonly AppDbContext _db;

    public StudentContoller(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("AddStudent")]
    public async Task<IActionResult> Add(AddStudentRequest request)
    {
        var entity = new Student();
        entity.Name = request.Name;
        entity.PersonalId = request.PersonalId;
        entity.Course = request.Course;
        entity.LastName = request.LastName;
       await  _db.Students.AddAsync(entity);
       await  _db.SaveChangesAsync();
       return Ok();
    }

   

    
}