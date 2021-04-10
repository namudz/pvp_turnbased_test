using System;
using Heroes.Attacks;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Services.ImageBank
{
    [Serializable]
    public class HeroAttackSpriteConfig
    {
        public HeroAttackType.Type Type;
        public Sprite Icon;
    }
}