using System.Collections.Generic;

namespace SpentBook.FileHelper.Parser
{
    public interface IFileParser
    {
        IEnumerable<Transaction> Parse();
    }
}