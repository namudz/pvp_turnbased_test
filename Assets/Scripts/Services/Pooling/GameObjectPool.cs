using System.Collections.Generic;
using Services.EventDispatcher;
using UnityEngine;

namespace Services.Pooling
{
    public abstract class GameObjectPool<T> : IGameObjectPool<T> where T : IPoolable
    {
        private readonly IEventDispatcher _eventDispatcher;
        private Transform _transform;
        private readonly GameObject _prefab;
        private readonly int _initialAmount;

        private readonly List<GameObject> _inactiveInstances;
        private readonly List<GameObject> _activeInstances;

        public GameObjectPool(GameObjectPoolData data, IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
            _transform = data.RootTransform;
            _prefab = data.Prefab;
            _initialAmount = data.InitialAmount;
            
            _inactiveInstances = new List<GameObject>(_initialAmount);
            _activeInstances = new List<GameObject>(_initialAmount);
            
            //_eventDispatcher.Subscribe<GameDestroyedSignal>(ResetCollections);
        }
        
        public void InstantiateInitialElements(Transform poolsParent)
        {
            _transform = poolsParent;
            for (var i = 0; i < _initialAmount; i++)
            {
                InstantiateElement();
            }
        }

        public GameObject GetInstance(Vector3 newPosition)
        {
            if (_inactiveInstances.Count == 0)
            {
                InstantiateElement();
            }

            var instance = _inactiveInstances[0];
            _inactiveInstances.RemoveAt(0);
            
            instance.transform.position = newPosition;
            instance.SetActive(true);
            _activeInstances.Add(instance);
            
            return instance;
        }

        public void BackToPool(GameObject instance)
        {
            _activeInstances.Remove(instance);
            if (!_inactiveInstances.Contains(instance))
            {
                _inactiveInstances.Add(instance);
            }
        }

        private void InstantiateElement()
        {
            var instance = Object.Instantiate(_prefab, _transform.position, Quaternion.identity, _transform);
            instance.SetActive(false);
            _inactiveInstances.Add(instance);
        }

        private void ResetCollections(ISignal signal)
        {
            _inactiveInstances.Clear();
            _activeInstances.Clear();
        }
    }
}