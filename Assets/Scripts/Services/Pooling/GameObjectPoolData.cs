using System;
using UnityEngine;

namespace Services.Pooling
{
    [Serializable]
    public class GameObjectPoolData
    {
        public Transform RootTransform { get; set; }
        public GameObject Prefab;
        public int InitialAmount;
    }
}