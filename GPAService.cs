using GpaCalculator.Api.Db;
using GpaCalculator.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GpaCalculator.Api;

public interface IGPAService
{
   List<double> GetScores(int studentId);
 
   double GetSumOfGPs(List<double> Gps);
   int GetSumOfCredits();
   double CalculateGPA(double GPs, int credits);
}
public class GPAService  : IGPAService
{
    private readonly AppDbContext _db;

    public GPAService(AppDbContext db)
    {
        _db = db;
    }
    public List<double> GetScores(int studentId)
    {
        var credits =  _db.Grades.Where(t => t.StudentId == studentId).Select(t=>t.subject.Credit).ToList();
        var scores = _db.Grades.Where(t => t.StudentId == studentId).Select(t=>t.Score.GetGps()).ToList();
        List<double> result = new List<double>();
        for (int i = 0; i < credits.Count; i++)
        {
            result.Add(credits[i] * scores[i]);
        }
        return result;
    }
    public double GetSumOfGPs(List<double> Gps)
    {
        double sum = 0;
        foreach (var item in Gps)
        {
            sum += item;
        }
        return sum;
    }
    public int GetSumOfCredits()
    {
        var credits =  _db.Grades.Sum(e => e.subject.Credit);
        return credits;
    }
    public double CalculateGPA(double GPs, int credits)
    {
        return GPs / credits;
    }
}