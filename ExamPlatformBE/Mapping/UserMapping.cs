using System;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;

namespace ExamPlatformBE.Mapping;

public static class UserMapping
{
      public static UserDetailDto ToDetailsDto(this User user)
    {
            return new(
                    user.Id,
                    user.Username,
                    user.Email
                   
                );
    }

      public static UserDto ToDto(this User user)
    {
            return new(
                    user.Id,
                    user.Username,
                    // user.Genre!.Name, //The ! operator is used to tell the compiler that, despite the nullable type, you are certain that game.Genre is not null at this point in the code.
                    user.Email,
                    user.Password
                );
    }

}
