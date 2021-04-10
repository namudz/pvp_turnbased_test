using System;
using Heroes.Abilities.Types;
using UnityEngine;

namespace Services.ImageBank
{
    [Serializable]
    public class HeroAbilitySpriteConfig
    {
        public HeroAbilityType.Type Type;
        public Sprite Icon;
    }
}