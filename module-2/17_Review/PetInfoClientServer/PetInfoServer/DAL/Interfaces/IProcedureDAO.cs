﻿using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.DAL.Interfaces
{
    public interface IProcedureDAO
    {
        List<Procedures> GetProcedures();
    }
}
