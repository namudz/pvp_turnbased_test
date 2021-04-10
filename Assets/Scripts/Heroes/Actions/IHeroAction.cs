namespace Heroes.Actions
{
    public interface IHeroAction
    {
        HeroActionType.Type Type { get; }
    }
}