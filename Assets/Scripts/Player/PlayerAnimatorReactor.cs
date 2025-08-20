using System;
using Observer;
using UnityEngine;

namespace Player{
    public class PlayerAnimatorReactor : MonoBehaviour{
        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }
    }
}