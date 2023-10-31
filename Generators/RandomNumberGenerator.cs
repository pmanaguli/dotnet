namespace GuessingGame.Generators;
public class RandomNumberGenerator : INumberGenerator
{
    public int Generate(int endRange)
    {
        Random rnd = new Random();
        int generatedNo = rnd.Next(1, endRange);
        return generatedNo;
    }
}
