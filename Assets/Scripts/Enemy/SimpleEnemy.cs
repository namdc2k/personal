using System;
using Core;
using UnityEngine;

namespace Enemy{
    public class SimpleEnemy : MonoBehaviour, IEnemy, IHealth, IMovable{
        [SerializeField] private int max = 50;
        private Rigidbody2D _rigid;
        private Transform _player;
        private SpriteRenderer _sprite;
        private EnemySpawner _spawner;
        private CapsuleCollider2D _collider;
        private Animator _animator;
        public int Max => max;
        public int Current { get; private set; }
        public event Action<int, int> OnHealthChanged;

        void Awake() {
            Current = Max;
            _player = GameObject.FindWithTag("Player")?.transform;
            _rigid = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<CapsuleCollider2D>();
            _animator = GetComponent<Animator>();
        }

        public float Speed { get; set; }
        public float Damage { get; set; }
        public int Health { get; set; }

        public void Spawned(EnemySpawner spawner, int health, float damage, float speed) {
            gameObject.SetActive(true);
            Health = health;
            Damage = damage;
            Speed = speed;
            _spawner = spawner;
            max = health;
            _collider.enabled = true;
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation, RuntimeAnimatorController animator) {
            transform.position = position;
            transform.rotation = rotation;
            if (_animator == null) _animator.GetComponent<Animator>();
            _animator.runtimeAnimatorController = animator;
        }

        void FixedUpdate() {
            if (_player == null) return;
            Vector2 dir = (_player.position - transform.position).normalized;
            Move(dir, Time.fixedDeltaTime);
        }

        private void LateUpdate() {
            if (_player == null) return;
            _sprite.flipX = _player.position.x < transform.position.x;
        }

        public void TakeDamage(int amount) {
            Current = Mathf.Max(0, Current - amount);
            OnHealthChanged?.Invoke(Current, Max);
            if (Current == 0) {
                _spawner.ReturnPool(this);
            }
        }

        public void Move(Vector2 dir, float deltaTime) {
            _rigid.MovePosition(_rigid.position + dir * Speed * deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("Player")) {
                TakeDamage(100);
                _collider.enabled = false;
            }
        }
    }
}