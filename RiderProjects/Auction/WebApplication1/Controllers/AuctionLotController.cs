using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Auction.Models;
using BLL.DTOs;
using BLL.Interfaces;

namespace WebApplication1.Controllers
{
    public class AuctionLotController : ApiController
    {
        private IAuctionLotService _auctionLotService;

        public AuctionLotController()
        {
            
        }

        public AuctionLotController(IAuctionLotService auctionLotService)
        {
            _auctionLotService = auctionLotService;
        }
        
        
        public IHttpActionResult GetAuctionLots()
        {
            var lot = HomeController._auctionLotService.GetLots();
            var newLots = HomeController._mapper.Map<IEnumerable<AuctionLot>>(lot);
            return Ok(newLots);
        }
        
        public IHttpActionResult GetAuctionLot(int id)
        {
            var lot = HomeController._auctionLotService.GetLots().SingleOrDefault(l => l.Id == id);
            var newLot = HomeController._mapper.Map<AuctionLot>(lot);
            if (newLot == null)
                return BadRequest();
            return Ok(newLot);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult AddLot(AuctionLot auctionLot)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newLot = HomeController._mapper.Map<AuctionLotDTO>(auctionLot);
            HomeController._auctionLotService.AddLot(newLot);
            return Created(new Uri(Request.RequestUri + "/" + newLot.Id), auctionLot.Id);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateLot(AuctionLot auctionLot, int newBet)
        {
            if (auctionLot != null && auctionLot.LastBet < newBet)
            {
                HomeController._auctionLotService.UpdateLot(auctionLot.Id, newBet);
            }
            else
            {
                ModelState.AddModelError("auction", "You can't make a bet lower than equal");
                return BadRequest(ModelState);
            }

            return Ok();
        }
        
        [Authorize]
        [HttpDelete]
        public void DeleteLot(int id)
        {
            HomeController._auctionLotService.DeleteLot(id);
        }
        
        protected override void Dispose(bool disposing)
        { 
            _auctionLotService.Dispose();
            base.Dispose(disposing);
        }
    }
}