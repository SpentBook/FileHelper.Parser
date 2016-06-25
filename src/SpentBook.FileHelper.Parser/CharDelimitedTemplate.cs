using System;

namespace SpentBook.FileHelper.Parser
{
    class CharDelimitedTemplate : ITemplate<string>
    {
        private readonly char delimiter;
        private readonly int transactionValueIndex;
        private readonly int transactionDateIndex;
        private readonly int descriptionIndex;

        public CharDelimitedTemplate(int transactionValueIndex, int transactionDateIndex, int descriptionIndex)
            : this(';', transactionValueIndex, transactionDateIndex, descriptionIndex)
        { }

        public CharDelimitedTemplate(char delimiter, int transactionValueIndex, int transactionDateIndex, int descriptionIndex)
        {
            this.delimiter = delimiter;
            this.transactionValueIndex = transactionValueIndex;
            this.transactionDateIndex = transactionDateIndex;
            this.descriptionIndex = descriptionIndex;
        }

        public Transaction GetTransaction(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value can not be null or empty.", nameof(value));
            }
            if (value.IndexOf(Environment.NewLine) != -1)
            {
                throw new ArgumentException("The data to be parsed must have only one line.", nameof(value));
            }

            var transactionData = value.Split(new char[] { delimiter });
            return new Transaction
            {
                TransactionValue = decimal.Parse(transactionData[transactionValueIndex]),
                TransactionDate = DateTime.Parse(transactionData[transactionDateIndex]),
                Description = transactionData[descriptionIndex]
            };
        }
    }
}