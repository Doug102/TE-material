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
    public class TransferController : ControllerBase
    {
        private ITransferDAO transferDAO;
        private IAccountDAO accountDAO;
        private IUserDAO userDAO;

        public TransferController(ITransferDAO transferDAO, IAccountDAO accountDAO, IUserDAO userDAO)
        {
            this.transferDAO = transferDAO;
            this.accountDAO = accountDAO;
            this.userDAO = userDAO;
        }

        [HttpPost]
        public IActionResult CreateNewSendTransfer(Transfer transfer)
        {
            decimal balance = accountDAO.GetBalance(transfer.SenderUserId);
            if (balance < transfer.Amount)
            {
                return BadRequest();
            }
            int accId = transferDAO.GetAccountFromUserId(transfer.SenderUserId);
            int recipientAccId = transferDAO.GetAccountFromUserId(transfer.RecipientUserId);
            int transferId = transferDAO.CreateNewSendTransfer(transfer.Amount, accId, recipientAccId);
            if (transferId != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("request")]
        public ActionResult<int> CreateNewRequest(Transfer transfer)
        {
            int accId = transferDAO.GetAccountFromUserId(transfer.SenderUserId);
            int recipientAccId = transferDAO.GetAccountFromUserId(transfer.RecipientUserId);
            int transferId = transferDAO.CreateNewRequest(transfer.Amount, accId, recipientAccId);
            if (transferId != 0)
            {
                return Ok(transferId);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        public ActionResult<List<Transfer>> ListTransfersByUserId(int userId)
        {
            int accId = transferDAO.GetAccountFromUserId(userId);
            List<Transfer> transfersByAccount = transferDAO.GetTransferById(accId);
            foreach (Transfer tr in transfersByAccount)
            {
                tr.RecipientUsername = userDAO.GetUsernameFromId(tr.RecipientUserId);
                tr.SenderUsername = userDAO.GetUsernameFromId(tr.SenderUserId);
            }
            if (transfersByAccount.Count > 0)
            {
                return Ok(transfersByAccount);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("user/pending/{userId}")]
        public ActionResult<List<Transfer>> ListPendingTransfersByUserId(int userId)
        {
            int accId = transferDAO.GetAccountFromUserId(userId);
            List<Transfer> pendingtransfersByAccount = transferDAO.GetPendingTransferById(accId);
            foreach (Transfer tr in pendingtransfersByAccount)
            {
                tr.RecipientUsername = userDAO.GetUsernameFromId(tr.RecipientUserId);
                tr.SenderUsername = userDAO.GetUsernameFromId(tr.SenderUserId);
            }
            if (pendingtransfersByAccount.Count > 0)
            {
                return Ok(pendingtransfersByAccount);
            }
            else if (pendingtransfersByAccount.Count == 0)
            {
                List<Transfer> transfer = new List<Transfer>();
                return Ok(transfer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("user/respondpending")]
        public IActionResult ApproveOrRejectRequest(Transfer transfer)
        {
            bool success = false;
            if (transfer.TransferStatus == "Approved")
            {
                decimal balance = accountDAO.GetBalance(transfer.SenderUserId);
                if (balance < transfer.Amount)
                {
                    return Forbid("Not enough money.");
                }
                success = transferDAO.ApproveRequest(transfer);
            }
            else if (transfer.TransferStatus == "Rejected")
            {
                success = transferDAO.RejectRequest(transfer);
            }

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
