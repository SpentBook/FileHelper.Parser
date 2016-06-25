using System.Collections.Generic;
using System.IO;

namespace SpentBook.FileHelper.Parser
{
    public class PlainTextFileParser : IFileParser
    {
        private const int TRANSACTION_VALUE_INDEX = 2;
        private const int TRANSACTION_DATE_INDEX = 0;
        private const int DESCRIPTION_INDEX = 1;

        private readonly string fileName;
        private readonly ITemplate<string> defaultTemplate;

        public PlainTextFileParser(string fileName)
        {
            this.fileName = fileName;
            defaultTemplate = new CharDelimitedTemplate(TRANSACTION_VALUE_INDEX, TRANSACTION_DATE_INDEX, DESCRIPTION_INDEX);
        }

        public IEnumerable<Transaction> Parse()
        {
            return Parse(defaultTemplate);
        }

        public IEnumerable<Transaction> Parse(ITemplate<string> template)
        {
            var transactions = new List<Transaction>();
            using (var file = File.OpenText(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var transaction = template.GetTransaction(line);
                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
    }
}