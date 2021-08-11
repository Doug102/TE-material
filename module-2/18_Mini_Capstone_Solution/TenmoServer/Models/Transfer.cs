using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Transfer
    {
        public decimal Amount { get; set; }
        public int SenderUserId { get; set; }
        public int RecipientUserId { get; set; }
        public int TransferId { get; set; }
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public string TransferType { get; set; }
        public string TransferStatus { get; set; }
    }
}
