using Heroes.Abilities;
using Heroes.Abilities.Types;
using Heroes.Actions;
using Heroes.Attacks;
using Heroes.Attacks.Types;
using Heroes.Health;
using JetBrains.Annotations;

namespace Heroes
{
    public class Hero
    {
        public event System.Action<HeroActionType.Type> OnStartSimulatingAction;
        
        public HealthPoints HealthPoints;
        public IHeroAttack Attack;
        [CanBeNull] public IHeroAbility Ability;

        public Hero(HeroStatsConfig stats)
        {
            HealthPoints = new HealthPoints(stats.HealthPoints);
            Attack = AttackFactory.GetAttack(stats.AttackConfig);
            Ability = AbilityFactory.GetAbility(stats.AbilityConfig);
        }

        public void StartSimulatingAction(HeroActionType.Type actionType)
        {
            OnStartSimulatingAction?.Invoke(actionType);
        }
    }
}