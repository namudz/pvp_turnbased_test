using Services;
using Services.EventDispatcher;
using Services.Pooling;

namespace Heroes.Attacks.Bullets
{
    public class BulletHotDogPool : GameObjectPool<BulletController>
    {
        public BulletHotDogPool(GameObjectPoolData data) : base(data, ServiceLocator.Instance.GetService<IEventDispatcher>())
        {
        }
    }
}