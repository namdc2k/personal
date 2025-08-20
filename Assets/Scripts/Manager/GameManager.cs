using Player;
using UnityEngine;

namespace Manager{
    public class GameManager : MonoBehaviour{
        public static GameManager Instance;
        public PlayerMovement player;

        private void Awake() {
            Instance = this;
        }
    }
}