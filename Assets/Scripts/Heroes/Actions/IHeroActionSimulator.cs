namespace Heroes.Actions
{
    public interface IHeroActionSimulator
    {
        event System.Action OnActionSimulated;
        void CanSimulate();
    }
}