using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfChildrenAPI.Models
{
    public enum OPERATION
    {
        WITHDRAW,
        DEPOSIT
    }
    public class Tansaction
    {
        public OPERATION Operation { get; set; } 
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
