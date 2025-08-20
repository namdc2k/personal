using Core;
using UnityEngine;

namespace Weapons{
    [CreateAssetMenu(menuName = "Weapons/Sword")]
    public class SwordConfig : WeaponConfig{
        [SerializeField] private float damage = 25f;
        [SerializeField] private float range = 1.8f;
        [SerializeField] private LayerMask hitMask;

        private class SwordWeapon : IWeapon{
            private readonly float dmg, rng;
            private readonly LayerMask mask;

            public SwordWeapon(float d, float r, LayerMask m) {
                dmg = d;
                rng = r;
                mask = m;
            }

            public void Fire(Transform owner) {
                // chém hình nón đơn giản phía trước
                if (Physics.SphereCast(owner.position, 0.5f, owner.forward, out var hit, rng, mask)) {
                    hit.collider.GetComponent<IHealth>()?.TakeDamage(Mathf.RoundToInt(dmg));
                    Debug.Log("Sword hit " + hit.collider.name);
                }
            }
        }

        public override IWeapon CreateInstance() => new SwordWeapon(damage, range, hitMask);
    }
}