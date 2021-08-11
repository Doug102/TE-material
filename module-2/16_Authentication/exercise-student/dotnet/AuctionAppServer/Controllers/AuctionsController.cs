using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using Microsoft.AspNetCore.Authorization;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao _dao;

        public AuctionsController(IAuctionDao auctionDao = null)
        {
            if (auctionDao == null)
                _dao = new AuctionDao();
            else
                _dao = auctionDao;
        }
        [AllowAnonymous]
        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return _dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return _dao.SearchByPrice(currentBid_lte);
            }

            return _dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = _dao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "creator, admin")]
        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction returnAuction = _dao.Create(auction);
            return Created($"/auctions/{returnAuction.Id}", returnAuction);
        }
        [Authorize(Roles = "creator, admin")]
        [HttpPut("{id}")]
        public ActionResult<Auction> Update(int id, Auction auction)
        {
            Auction existingAuction = _dao.Get(id);
            if (existingAuction == null)
            {
                return NotFound("Auction does not exist");
            }

            Auction result = _dao.Update(id, auction);
            return Ok(result);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Auction auction = _dao.Get(id);
            if (auction == null)
            {
                return NotFound("Auction does not exist");
            }

            bool result = _dao.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("whoami")]
        public ActionResult WhoAmI()
        {
            return Ok(User.Identity.Name);
        }
    }
}
