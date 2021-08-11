using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private IProcedureDAO procedureDAO;
        public ProceduresController(IProcedureDAO procedureDAO)
        {
            this.procedureDAO = procedureDAO;
        }

        [HttpGet]
        public ActionResult<List<Procedures>> GetProcedures()
        {
            return Ok(procedureDAO.GetProcedures());
          
        }
    }
}
