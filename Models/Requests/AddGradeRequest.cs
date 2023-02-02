namespace GpaCalculator.Api.Models.Requests;

public class AddGradeRequest
{
    public int SubjectId { get; set; }
    public int StudentId { get; set; }
    public double Score { get; set; }
}