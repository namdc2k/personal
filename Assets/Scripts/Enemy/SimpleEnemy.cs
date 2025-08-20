using System;
using Core;
using UnityEngine;

namespace Enemy{
    public class SimpleEnemy : MonoBehaviour, IEnemy, IHealth, IMovable{
        [SerializeField] private int max = 50;
        [SerializeField] private float speed = 2f;
        private Rigidbody2D _rigid;
        private Transform _player;
        private SpriteRenderer _sprite;

        public int Max => max;
        public int Current { get; private set; }
        public event System.Action<int, int> OnHealthChanged;

        void Awake() {
            Current = Max;
            _player = GameObject.FindWithTag("Player")?.transform;
            _rigid = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Spawned() {
            Debug.Log($"{name} spawned");
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
            if (Current == 0) Destroy(gameObject);
        }

        public void Move(Vector2 dir, float deltaTime) {
            _rigid.MovePosition(_rigid.position + dir * speed * deltaTime);
        }
    }
}