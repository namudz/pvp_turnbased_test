using Services.EventDispatcher;

namespace Heroes.Selector
{
    public class HeroSelectedSignal : ISignal
    {
        public Hero Hero { get; }

        public HeroSelectedSignal(Hero hero)
        {
            Hero = hero;
        }
    }
}