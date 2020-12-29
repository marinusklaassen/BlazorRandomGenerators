namespace RandomGenerators.Travesty
{
    public interface ITravestyGenerator
    {
        string ProcessText(string inputText, int characterSequenceMatchOrder, int maxLength = 0);
    }
}