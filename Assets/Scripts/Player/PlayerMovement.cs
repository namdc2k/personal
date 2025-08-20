using System;
using Core;
using UnityEngine;

namespace Player{
    public class PlayerMovement : MonoBehaviour, IMovable{
        [SerializeField] private float moveSpeed = 5f;
        private Rigidbody2D _rb;
        private Vector2 _inputVec;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 dir, float dt) {
            Vector2 nextVec = dir.normalized * moveSpeed * dt;
            _rb.MovePosition(_rb.position + nextVec);
        }

        private void Update() {
            _inputVec.x = Input.GetAxisRaw("Horizontal");
            _inputVec.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate() {
            Move(_inputVec, Time.fixedDeltaTime);
        }
    }
}