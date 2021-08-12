using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        int CreateNewSendTransfer(decimal amount, int accId, int recipientAccId);
        int GetAccountFromUserId(int userId);
        bool MoveMoneyBetweenAccounts(decimal amount, int accId, int recipientAccId);
        List<Transfer> GetTransferById(int accId);
        int CreateNewRequest(decimal amount, int accId, int recipientAccId);
        List<Transfer> GetPendingTransferById(int accId);

        /// <summary>
        /// Assumes sender balance is sufficient to send the money.
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        bool ApproveRequest(Transfer transfer);
        bool RejectRequest(Transfer transfer);
    }
}
