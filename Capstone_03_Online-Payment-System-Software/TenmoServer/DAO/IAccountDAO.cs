using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        Account GetBalance(int userId);
        int GetAccountIdFromUserId(int id);

        Account GetUserNameByAccountId(int id);
    }
}
