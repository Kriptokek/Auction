using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL
{
    public class UserService : IUserService
    {
        private IUnitOfWork DataBase { get; set; }
        private IMapper _mapper;

        public UserService(IUnitOfWork uow)
        {
            DataBase = uow;
            var mapconfig = new MapperConfiguration(m=>m.AddProfile(new MapConfig()));
            _mapper = mapconfig.CreateMapper();
        }
        
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = DataBase.UserRepository.GetAll();
            List<UserDTO> list = new List<UserDTO>();
            foreach (var item in users)
            {
                list.Add(_mapper.Map<UserDTO>(item));
            }

            return list;
        }

        public void AddUser(UserDTO userDto)
        {
            if(userDto == null)
                throw new ValidationException("User is not created");
            var user = _mapper.Map<User>(userDto);
            DataBase.UserRepository.Add(user);
            DataBase.Save();
        }

        public void DeleteUser(int id)
        {
            var user = GetUsers().SingleOrDefault(u => u.Id == id);
            if(user == null)
                throw new ValidationException("User was not found");
            DataBase.UserRepository.Delete(user.Id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}