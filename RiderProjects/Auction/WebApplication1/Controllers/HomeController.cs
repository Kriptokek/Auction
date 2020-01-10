using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.Interfaces;
using WebApplication2;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public static IUserService _userService;
        public static IProductService _productservice;
        public static IAuctionLotService _auctionLotService;
        public static IMapper _mapper;

        public HomeController(IUserService userService, IProductService productService, IAuctionLotService auctionLotService)
        {
            _userService = userService;
            var mapconfig = new MapperConfiguration(m=>m.AddProfile(new MapperProfile()));
            _mapper = mapconfig.CreateMapper();
            _productservice = productService;
            _auctionLotService = auctionLotService;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            var users = _userService.GetUsers();
            return View(users);
        }
    }
}
