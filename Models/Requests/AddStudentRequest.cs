namespace GpaCalculator.Api.Models.Requests;

public class AddStudentRequest
{
    public string Name { get; set; }
    public int PersonalId { get; set; }
    public string Course { get; set; }
    public string LastName { get; set; }
}