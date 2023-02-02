using GpaCalculator.Api.Db;
using GpaCalculator.Api.Models.Entities;
using GpaCalculator.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GpaCalculator.Api.Controllers;
[ApiController]
[Route("Grade/[controller]")]
public class GradeController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IGPAService _gpaService;

    public GradeController(AppDbContext db, IGPAService gpaService)
    {
        _db = db;
        _gpaService = gpaService;
    }

    [HttpPost("AddGrade")]
    public async Task<IActionResult> Add(AddGradeRequest request)
    {
        var entity = new Grade();
        entity.SubjectId = request.SubjectId;
        entity.Score = request.Score;
        entity.StudentId = request.StudentId;
        await _db.Grades.AddAsync(entity);
        await _db.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("Get-Grade-List")]
    public async Task<IActionResult> GetGradeList(int studentId)
    {
        var grades = await _db.Grades.Where(t => t.StudentId == studentId).Select(t=>t.Score).ToListAsync();
        return Ok(grades);
    }

    [HttpPost("GPA")]
    public async Task<IActionResult> CalculateGpa(int studentId)
    {
        var scores = _gpaService.GetScores(studentId);
        var sumOfGps = _gpaService.GetSumOfGPs(scores);
        var sumOfCredits = _gpaService.GetSumOfCredits();
        var GPA = _gpaService.CalculateGPA(sumOfGps, sumOfCredits);
        return Ok(GPA);
    }
}