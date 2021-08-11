using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountDAO accountDAO;
        public AccountsController(IAccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }

        [HttpGet]
        public ActionResult<Account> GetAccount()
        {
            return Ok(accountDAO.GetBalance(int.Parse(this.User.FindFirst("sub").Value)));
        }

        [HttpGet("{id}")]
        public ActionResult<int> GetAccountIdFromUserId(int id)
        {
            return Ok(accountDAO.GetAccountIdFromUserId(id));
        }
        [HttpGet("users/{id}")]
        public ActionResult<Account> GetUserNameByAccountId(int id)
        {
            return Ok(accountDAO.GetUserNameByAccountId(id));
        }
    }
}
