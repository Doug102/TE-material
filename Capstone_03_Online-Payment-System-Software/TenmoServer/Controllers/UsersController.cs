using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using TenmoServer.DAO;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserDAO userDAO;
        public UsersController(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> users = userDAO.GetUsers();// int.Parse(this.User.FindFirst("sub").Value));
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<Account> GetCurrentUser(int id)
        {
            Account account = userDAO.GetCurrentUser(id);
           //Account account = //transferDAO.GetCurrentUser(int.Parse(this.User.FindFirst("sub").Value));
            return Ok(account);
        }
    }
}
