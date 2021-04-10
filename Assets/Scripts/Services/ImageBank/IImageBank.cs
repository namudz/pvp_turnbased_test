using Heroes.Abilities;
using Heroes.Abilities.Types;
using Heroes.Attacks;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Services.ImageBank
{
    public interface IImageBank
    {
        Sprite GetMoveIcon();
        Sprite GetAttackIcon(HeroAttackType.Type type);
        Sprite GetAbilityIcon(HeroAbilityType.Type? type);
    }
}