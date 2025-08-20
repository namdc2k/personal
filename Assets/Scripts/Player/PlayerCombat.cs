using Core;
using UnityEngine;
using Weapons;

namespace Player{
    public class PlayerCombat : MonoBehaviour{
        [SerializeField] private WeaponConfig startingWeapon; // SO (abstraction)
        private IWeapon _weapon;

        void Start() {
            if (startingWeapon != null)
                _weapon = startingWeapon.CreateInstance();
        }

        void Update() {
            if (Input.GetMouseButtonDown(0))
                _weapon?.Fire(transform);
        }

        // Có thể switch vũ khí runtime mà không sửa code:
        public void Equip(WeaponConfig newConfig) => _weapon = newConfig.CreateInstance();
    }
}