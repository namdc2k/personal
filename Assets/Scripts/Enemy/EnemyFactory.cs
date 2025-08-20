using Core;
using UnityEngine;

namespace Enemy{
    public abstract class EnemyFactory : ScriptableObject{
        public float speed;
        public float damage;
        public int health;
        public abstract IEnemy Create(Transform parent);
    }
}