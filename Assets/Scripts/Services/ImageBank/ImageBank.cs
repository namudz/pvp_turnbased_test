using System.Collections.Generic;
using Heroes.Abilities.Types;
using Heroes.Attacks.Types;
using UnityEngine;

namespace Services.ImageBank
{
    public class ImageBank : MonoBehaviour, IImageBank
    {
        [Header("Hero Icons")]
        [SerializeField] private Sprite _movementIcon; 
        [SerializeField] private List<HeroAttackSpriteConfig> _attackIcons; 
        [SerializeField] private List<HeroAbilitySpriteConfig> _abilityIcons;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IImageBank>(this);
        }

        public Sprite GetMoveIcon()
        {
            return _movementIcon;
        }

        public Sprite GetAttackIcon(HeroAttackType.Type type)
        {
            return _attackIcons.Find(config => config.Type == type).Icon;
        }

        public Sprite GetAbilityIcon(HeroAbilityType.Type? type)
        {
            return type != null 
                ? _abilityIcons.Find(config => config.Type == type).Icon 
                : null;
        }
    }
}