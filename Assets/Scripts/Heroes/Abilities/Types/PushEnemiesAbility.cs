namespace Heroes.Abilities.Types
{
    public class PushEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PushEnemies;
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}