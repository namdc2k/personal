using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class UIHealthBar : MonoBehaviour{
        [SerializeField] private MonoBehaviour targetHealth;
        [SerializeField] private Image fill;

        private IHealth _health;

        void Awake() {
            _health = targetHealth as IHealth;
            if (_health == null) {
                Debug.LogError("targetHealth must implement IHealth");
                enabled = false;
                return;
            }

            _health.OnHealthChanged += UpdateUI;
            UpdateUI(_health.Current, _health.Max);
        }

        void OnDestroy() {
            if (_health != null) _health.OnHealthChanged -= UpdateUI;
        }

        void UpdateUI(int cur, int max) {
            if (fill != null) fill.fillAmount = max > 0 ? (float)cur / max : 0f;
        }
    }
}