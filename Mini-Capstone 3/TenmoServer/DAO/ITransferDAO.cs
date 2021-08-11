using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {

        List<User> GetUsers(int userId);
        Account GetCurrentUser(int currentUserId);
        bool PostTransfer(Transfer transfer);

        List<Transfer> GetTransfersForId(int id);

        bool UpdateTransferApproved(int id, Transfer transfer);
        bool UpdateTransferRejected(int id);

    }
}
