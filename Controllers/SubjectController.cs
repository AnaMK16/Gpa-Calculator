using System.Xml;
using GpaCalculator.Api.Db;
using GpaCalculator.Api.Models.Entities;
using GpaCalculator.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GpaCalculator.Api.Controllers;

[ApiController]
[Route("Subject/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly AppDbContext _db;

    public SubjectController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("Register-subject")]
    public async Task<IActionResult> AddSubject(AddSubjectRequest request)
    {
        var entity = new Subject();
        entity.Name = request.Name;
        entity.Credit = request.Credit;
        await _db.Subjects.AddAsync(entity);
        await _db.SaveChangesAsync();
        return Ok();
    }
}
    

  