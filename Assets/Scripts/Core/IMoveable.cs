using UnityEngine;

namespace Core{
    public interface IMovable{
        void Move(Vector2 dir, float deltaTime);
    }
}