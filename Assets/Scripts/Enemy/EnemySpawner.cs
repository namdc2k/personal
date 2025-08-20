using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy{
    public class EnemySpawner : MonoBehaviour{
        [SerializeField] private EnemyFactory factory;
        [SerializeField] private float radius = 8f;
        private Queue<IEnemy> _enemies;
        private Transform _player;

        private void Awake() {
            _player = GameObject.FindWithTag("Player")?.transform;
            _enemies = new();
        }

        [ContextMenu("Spawn One")]
        public void SpawnOne() {
            var p = _player.position + Random.onUnitSphere * radius;
            p.z = 0;
            if (_enemies.Count > 0) {
                var enemy = _enemies.Dequeue();
                SetUpData(enemy, p);
            }
            else {
                var enemy = factory.Create(transform);
                SetUpData(enemy, p);
            }
        }

        void SetUpData(IEnemy enemy, Vector3 position) {
            enemy.SetPositionAndRotation(position, quaternion.identity);
            enemy.Spawned(this, factory.health, factory.damage, factory.speed);
        }

        public void ReturnPool(IEnemy enemy) {
            (enemy as SimpleEnemy).gameObject.SetActive(false);
            _enemies.Enqueue(enemy);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) SpawnOne();
        }
    }
}