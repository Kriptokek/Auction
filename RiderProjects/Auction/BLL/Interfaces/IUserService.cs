using System.Collections.Generic;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        void AddUser(UserDTO userDto);
        void DeleteUser(int id);
        void Dispose();
    }
}