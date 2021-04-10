using Heroes.Abilities.Types;
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