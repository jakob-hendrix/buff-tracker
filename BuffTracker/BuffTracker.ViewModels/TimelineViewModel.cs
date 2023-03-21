namespace BuffTracker.ViewModels
{
    public class TimelineViewModel
    {
        public int IncrementRound(int currentRound) => currentRound + 1;

        public int DecrementRound(int currentRound)
        {
            int round = currentRound - 1;
            if (round < 0)
            {
                round = 0;
            }

            return round;
        }
    }
}
