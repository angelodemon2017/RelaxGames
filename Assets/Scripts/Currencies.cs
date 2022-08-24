public class Currencies
{
    public delegate void CoinsCount(int id);
    public static event CoinsCount coinsUpdate;

    public static bool TrySpendCoins(int count) 
    {
        if (DataController.data.Coins >= count) 
        {
            DataController.data.Coins -= count;
            coinsUpdate?.Invoke(DataController.data.Coins);

            return true;
        }

        return false;
    }

    public static void AddCoins(int count)
    {
        if (DataController.data != null)
        {
            DataController.data.Coins += count;
        }

        coinsUpdate?.Invoke(DataController.data.Coins);
    }
}