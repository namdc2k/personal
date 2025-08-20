using System;
using Enemy;
using UnityEngine;

namespace Core{
    public interface IEnemy{
        public float Speed { get; set; }
        public int Health { get; set; }
        public float Damage { get; set; }
        void Spawned(EnemySpawner spawner, int health, float damage, float speed);
        void SetPositionAndRotation(Vector3 position, Quaternion rotation);
    }
}