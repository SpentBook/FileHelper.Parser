using System;

namespace SpentBook.FileHelper.Parser
{
    public class Transaction
    {
        public decimal TransactionValue { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Description { get; set; }
    }
}