using System;
using Manager;
using UnityEngine;

namespace Map{
    public class Reposition : MonoBehaviour{
        [SerializeField] private float width;
        private void OnTriggerExit2D(Collider2D other) {
            if (!other.CompareTag("Area")) return;

            Vector3 playerPos = GameManager.Instance.player.transform.position;
            Vector3 myPos = transform.position;

            float xDiff = Mathf.Abs(playerPos.x - myPos.x);
            float yDiff = Mathf.Abs(playerPos.y - myPos.y);

            Vector3 playerDir = GameManager.Instance.player.InputVector;
            float xDir = playerDir.x < 0 ? -1 : 1;
            float yDir = playerDir.y < 0 ? -1 : 1;
            switch (transform.tag) {
                case "Ground":
                    if (xDiff > yDiff) {
                        transform.Translate(Vector3.right * xDir * width);
                    }
                    else if(xDiff < yDiff) {
                        transform.Translate(Vector3.up * yDir * width);
                    }
                    break;
            }
        }
    }
}