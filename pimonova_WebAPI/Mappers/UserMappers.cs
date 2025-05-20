using Microsoft.AspNetCore.Identity;
using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.User;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace pimonova_WebAPI.Mappers
{
    public static class UserMappers
    {
        public static UserDTO ToUserDTO(this User UserModel)
        {
            return new UserDTO
            {
                UserID = UserModel.UserID,
                Name = UserModel.Name,
                Surname = UserModel.Surname,
                Email = UserModel.Email,
                Role = UserModel.Role,
                Position = UserModel.Position,
                CompanyID = UserModel.CompanyID,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDTO UserDTO, int CompanyId)
        {
            var Hasher = new PasswordHasher<User>();
            //return new User
            //{
            //    Name = UserDTO.Name,
            //    Surname = UserDTO.Surname,
            //    Email = UserDTO.Email,
            //    //Role = UserDTO.Role,
            //    Position = UserDTO.Position,
            //    CompanyID = CompanyId,
            //    Login = UserDTO.Login,
            //    PasswordHash = UserDTO.Password
            //};

            var User = new User
            {
                Name = UserDTO.Name,
                Surname = UserDTO.Surname,
                Email = UserDTO.Email,
                Role = "User",
                Position = UserDTO.Position,
                CompanyID = CompanyId,
                Login = UserDTO.Login,
                //PasswordHash = UserDTO.Password
            };

            User.PasswordHash = Hasher.HashPassword(User, UserDTO.Password);
            return User;
        }

        public static User ToUserFromUpdateDTO(this UpdateUserRequestDTO UserDTO)
        {
            return new User
            {
                Name = UserDTO.Name,
                Surname = UserDTO.Surname,
                Email = UserDTO.Email,
                //Role = UserDTO.Role,
                Position = UserDTO.Position
            };
        }

        public static void MapRoleFromDTO(this User UserModel, UpdateUserRoleRequestDTO UpdateUserRoleDTO)
        {
            UserModel.Role = UpdateUserRoleDTO.Role;
        }
    }
}
