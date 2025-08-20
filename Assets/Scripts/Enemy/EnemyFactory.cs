using Core;
using UnityEngine;

namespace Enemy{
    public abstract class EnemyFactory : ScriptableObject{
        public abstract IEnemy Create(Vector3 position, Quaternion rotation);
    }
}