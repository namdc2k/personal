using System;
using Core;
using UnityEngine;

namespace Player{
    public class PlayerHealth : MonoBehaviour, IHealth{
        [SerializeField] private int max = 100;
        public int Max => max;
        public int Current { get; private set; }

        public event Action<int, int> OnHealthChanged;

        void Awake() {
            Current = Max;
            OnHealthChanged?.Invoke(Current, Max);
        }

        public void TakeDamage(int amount) {
            Current = Mathf.Max(0, Current - amount);
            OnHealthChanged?.Invoke(Current, Max);
            if (Current == 0) Debug.Log("Player died");
        }
    }
}