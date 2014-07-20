namespace BullsAndCows
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Score { get; set; }

        bool HasCheated { get; set; }

        int Attempts { get; set; }
    }
}
