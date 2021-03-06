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

        public int InstanceId;
        public HeroTypes.Team Team;
        public HealthPoints HealthPoints;
        public IHeroAttack Attack;
        public float MaxMovementForce;
        [CanBeNull] public IHeroAbility Ability;

        public Hero(int instanceId, HeroStatsConfig stats)
        {
            InstanceId = instanceId;
            Team = stats.Team;
            HealthPoints = new HealthPoints(stats.HealthPoints);
            MaxMovementForce = stats.MaxMovementForce;
            Attack = AttackFactory.GetAttack(stats.AttackConfig);
            Ability = AbilityFactory.GetAbility(stats.AbilityConfig);
        }

        public void StartSimulatingAction(HeroActionType.Type actionType)
        {
            OnStartSimulatingAction?.Invoke(actionType);
        }

        public bool IsAlive()
        {
            return HealthPoints.Current > 0;
        }
    }
}