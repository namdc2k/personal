using Core;
using UnityEngine;

namespace Weapons{
    [CreateAssetMenu(menuName = "Weapons/Gun")]
    public class GunConfig : WeaponConfig{
        [SerializeField] private float damage = 15f;
        [SerializeField] private float range = 30f;
        [SerializeField] private LayerMask hitMask;

        private class GunWeapon : IWeapon{
            private readonly float _dmg, _rng;
            private readonly LayerMask mask;

            public GunWeapon(float d, float r, LayerMask m) {
                _dmg = d;
                _rng = r;
                mask = m;
            }

            public void Fire(Transform owner) {
                var ray = new Ray(owner.position + owner.forward * 0.5f, owner.forward);
                if (Physics.Raycast(ray, out var hit, _rng, mask)) {
                    hit.collider.GetComponent<IHealth>()?.TakeDamage(Mathf.RoundToInt(_dmg));
                    Debug.Log("Gun hit " + hit.collider.name);
                }
            }
        }

        public override IWeapon CreateInstance() => new GunWeapon(damage, range, hitMask);
    }
}