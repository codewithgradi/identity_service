public static class USerMappers
{
  public static UserDto ToUserDto(this User user)
  {
    return new UserDto
    {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Username = user.Username,
      Age = user.Age,
      Courses = user.Courses
    };
  }
  public static User ToUserFromCreate(this CreateUserDto user)
  {
    return new User
    {
      Id = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Username = user.Username,
      Age = user.Age,
    };
  }
}