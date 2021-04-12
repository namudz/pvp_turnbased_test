using Heroes.Abilities;
using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityPushEnemiesCommand : AbilityCommand
    {
        private readonly Vector3 _casterPosition;

        public AbilityPushEnemiesCommand(Hero hero, HeroAbilityController abilityController, Vector3 casterPosition) : base(hero, abilityController)
        {
            _casterPosition = casterPosition;
        }

        public override void Execute()
        {
            if (_hero.Ability == null) { return; }
            
            ((PushEnemiesAbility)_hero.Ability).SetCasterPosition(_casterPosition);
            _abilityController.Cast(_hero.Team.GetRivalTeam(), LaunchOnCompletedEvent);
        }
    }
}