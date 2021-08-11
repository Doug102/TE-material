using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;

namespace TenmoServer.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountDAO accountDAO;

        public AccountController(IAccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }

        [Route("{userId}")]
        [HttpGet]
        public ActionResult<decimal> GetAccountBalance(int userId)
        {
            return Ok(accountDAO.GetBalance(userId));
        }


    }
}
