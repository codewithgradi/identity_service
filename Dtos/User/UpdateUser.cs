public class UpdateUserDto
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Username { get; set; }
  public int Age { get; set; }
  public List<Course> courses { get; set; } = new List<Course> { };
}