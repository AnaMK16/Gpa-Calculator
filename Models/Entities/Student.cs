namespace GpaCalculator.Api.Models.Entities;

public class Student
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Course { get; set; }
    public int PersonalId { get; set; }
    public List<Grade> Grades { get; set; }
    
}