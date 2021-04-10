namespace Heroes.Abilities.Types
{
    public class HealAlliesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.HealAllies;
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}