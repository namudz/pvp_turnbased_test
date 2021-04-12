using Heroes;
using Services.EventDispatcher;

namespace Game
{
    public class GameStartSignal : ISignal
    {
    }

    public class GameReadySignal : ISignal
    {
    }

    public class GameOverSignal : ISignal
    {
        public HeroTypes.Team TeamWinner;

        public GameOverSignal(HeroTypes.Team teamWinner)
        {
            TeamWinner = teamWinner;
        }
    }
}