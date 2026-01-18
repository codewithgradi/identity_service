using System.ComponentModel.DataAnnotations.Schema;

public class CourseDto
{
  public int Id { get; set; }
  public int StudentId { get; set; }
  public bool IsCompleted { get; set; } = false;
  public DateTime EnrolledOn { get; set; } = DateTime.Today;
  public DateTime CompletedOn { get; set; }
  public int ExamMark { get; set; } = 0;

  public int UserId { get; set; }

  public User? User { get; set; }
}