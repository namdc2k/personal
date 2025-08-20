using System;

namespace Core{
    public interface IHealth{
        int Current { get; }
        int Max { get; }
        event Action<int, int> OnHealthChanged;
        void TakeDamage(int amount);
    }
}