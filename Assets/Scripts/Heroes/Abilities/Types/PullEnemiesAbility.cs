namespace Heroes.Abilities.Types
{
    public class PullEnemiesAbility : IHeroAbility
    {
        public HeroAbilityType.Type Type => HeroAbilityType.Type.PullEnemies;
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}