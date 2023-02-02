namespace GpaCalculator.Api.Models.Entities;

public class Grade
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public int StudentId { get; set; }
    public double Score { get; set; }
    public Subject subject { get; set; }
    public Student student { get; set; }
}