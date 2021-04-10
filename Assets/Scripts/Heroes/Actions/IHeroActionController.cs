using System;

namespace Heroes.Actions
{
    public interface IHeroActionController
    {
        event Action OnActionSimulated;
    }
}