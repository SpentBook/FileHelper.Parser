using System.Collections.Generic;
using System.IO;
using System.Linq;
using OFXSharp;

namespace SpentBook.FileHelper.Parser
{
    public class OfxFileParser : IFileParser
    {
        private readonly string fileName;

        public OfxFileParser(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<Transaction> Parse()
        {
            var transactions = new List<Transaction>();
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var parser = new OFXDocumentParser();
                var ofxDocument = parser.Import(fileStream);

                return from f in ofxDocument.Transactions
                       select new Transaction
                       {
                           TransactionValue = f.Amount,
                           TransactionDate = f.Date,
                           Description = f.Memo
                       };
            }
        }
    }
}