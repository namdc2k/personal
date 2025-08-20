using Core;
using UnityEngine;

namespace Enemy{
    [CreateAssetMenu(menuName = "Enemies/Zombie Factory")]
    public class ZombieFactory : EnemyFactory{
        [SerializeField]private GameObject zombiePrefab;
        public override IEnemy Create(Transform parent) {
            var go  = Instantiate(zombiePrefab, parent);
            return go.GetComponent<IEnemy>();
        }
    }
}