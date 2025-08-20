using Core;
using UnityEngine;

namespace Weapons{
    public abstract class WeaponConfig : ScriptableObject{
        public abstract IWeapon CreateInstance();
    }
}