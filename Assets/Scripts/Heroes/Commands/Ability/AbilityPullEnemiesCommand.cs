using Heroes.Abilities;
using Heroes.Abilities.Types;
using UnityEngine;

namespace Heroes.Commands.Ability
{
    public class AbilityPullEnemiesCommand : AbilityCommand
    {
        private readonly Vector3 _casterPosition;

        public AbilityPullEnemiesCommand(Hero hero, HeroAbilityController abilityController, Vector3 casterPosition) : base(hero, abilityController)
        {
            _casterPosition = casterPosition;
        }

        public override void Execute()
        {
            if (_hero.Ability == null) { return; }

            ((PullEnemiesAbility)_hero.Ability).SetCasterPosition(_casterPosition);
            _abilityController.Cast(_hero.Team.GetRivalTeam(), LaunchOnCompletedEvent);
        }
    }
}