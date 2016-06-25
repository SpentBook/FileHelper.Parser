namespace SpentBook.FileHelper.Parser
{
    public interface ITemplate<T>
    {
        Transaction GetTransaction(T value);
    }
}