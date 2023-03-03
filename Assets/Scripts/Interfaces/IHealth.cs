using System;


namespace SlimeRpg
{
    public interface IHealth
    {
        event Action<int> OnHealthChanged;
        public int Health { get; }
        public int MaxHealth { get; }
    }
}
