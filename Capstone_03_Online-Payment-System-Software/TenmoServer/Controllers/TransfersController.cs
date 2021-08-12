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
    public class TransfersController : ControllerBase
    {
        private ITransferDAO transferDAO;
        public TransfersController(ITransferDAO transferDAO)
        {
            this.transferDAO = transferDAO;
        }



        [HttpPost]
        public ActionResult<bool> PostTransfer(Transfer transfer)
        {
            bool result = transferDAO.PostTransfer(transfer);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<List<Transfer>> GetTransfersForId(int id)
        {
            List<Transfer> transfers = transferDAO.GetTransfersForId(id);

            return Ok(transfers);

        }
        [HttpPut("approved/{id}")]
        public ActionResult<bool> UpdateTransferApproved(int id, Transfer transfer)
        {
            
            bool result = transferDAO.UpdateTransferApproved(id, transfer);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }
        [HttpPut("rejected/{id}")]
        public ActionResult<bool> UpdateTransferRejected(int id)
        {
            bool result = transferDAO.UpdateTransferRejected(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }





    }
}
