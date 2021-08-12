using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;


namespace TenmoServer.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDAO userDAO;

        public UserController(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        [Route("{userId}")]
        [HttpGet]
        public ActionResult<string> GetUsernameFromId(int userId)
        {
            return Ok(userDAO.GetUsernameFromId(userId));
        }

        [Route("listother/{userId}")]
        [HttpGet]
        public ActionResult<List<User>> GetOtherUsers(int userId)
        {
            List<User> users = userDAO.GetUsers();
            List<User> modifiedUsers = new List<User>();
            foreach(User user in users)
            {
                if (user.UserId != userId)
                {
                    modifiedUsers.Add(user);
                }
            }
            return Ok(modifiedUsers);
        }
    }
}
