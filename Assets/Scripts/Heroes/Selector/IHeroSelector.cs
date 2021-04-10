namespace Heroes.Selector
{
    public interface IHeroSelector
    {
        bool IsSelectable {get;}
        bool Select();
        void ResetSelectable();
    }
}