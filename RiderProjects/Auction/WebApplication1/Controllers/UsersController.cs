using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Auction.Models;
using AutoMapper;
using BLL;
using BLL.DTOs;
using BLL.Interfaces;
using Ninject.Infrastructure.Language;
using WebApplication1.Controllers;

namespace Auction.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController()
        {
            
        }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        public IHttpActionResult GetUsers()
        {
            var user = HomeController._userService.GetUsers();
            var newUsers = HomeController._mapper.Map<IEnumerable<User>>(user);
            return Ok(newUsers);
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = HomeController._userService.GetUsers().SingleOrDefault(u => u.Id == id);
            var newUser = HomeController._mapper.Map<User>(user);
            if (newUser == null)
                return BadRequest();
            return Ok(newUser);
        }


        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newUser = HomeController._mapper.Map<UserDTO>(user);
            HomeController._userService.AddUser(newUser);
            return Created(new Uri(Request.RequestUri + "/" + newUser.Id), user.Id);
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            HomeController._userService.DeleteUser(id);
        }
        
        protected override void Dispose(bool disposing)
        { 
            _userService.Dispose();
            base.Dispose(disposing);
        }
    }
}