public static class CourseMappers
{
  public static CourseDto ToCourseDto(this Course course)
  {
    return new CourseDto
    {
      Id = course.Id,
      CompletedOn = course.CompletedOn,
      StudentId = course.StudentId,
      IsCompleted = course.IsCompleted,
      EnrolledOn = course.EnrolledOn,
      ExamMark = course.ExamMark,
      UserId = course.UserId,
    };
  }
  public static Course ToCourseFromCreate(this CreateCourseDto course)
  {
    return new Course
    {
      Id = course.Id,
      CompletedOn = course.CompletedOn,
      StudentId = course.StudentId,
      IsCompleted = course.IsCompleted,
      EnrolledOn = course.EnrolledOn,
      ExamMark = course.ExamMark,
      UserId = course.UserId,
    };
  }
}