using System;


namespace SlimeRpg
{
    public sealed class SlimeHealth : ITakeDamag, IHealth
    {

        #region Fields

        public event Action<int> OnHealthChanged;

        private HpIndicator _hpIndicator;

        private int _maxHealth;
        private int _currentHealth;

        private bool _isInitialized;

        #endregion


        #region Properties

        public int Health { get => _currentHealth; }

        public int MaxHealth { get => _maxHealth; }

        #endregion


        #region ClassLifeCycles

        public SlimeHealth(GamePlaySettings gps)
        {
            _maxHealth = gps.BaseSlimeHealth;
        }

        #endregion


        #region Methods

        public void Initialize()
        {
            ResetHealth();
            if (!_isInitialized)
            {
                _isInitialized = true;
                SlimeBody slimeBody = Services.Instance.Factory.GetSlimeBody();
                _hpIndicator = slimeBody.GetHpIndicator();
                _hpIndicator.SetIHealth(this);
                slimeBody.SetTekerDamag(this);
            }
            _hpIndicator.ResetValues();
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }

        #endregion


        #region ITakeDamag

        public void TakeDamage(int amount)
        {
            if (amount > 0)
            {
                _currentHealth -= amount;
                if (_currentHealth < 0)
                {
                    _currentHealth = 0;
                }
                OnHealthChanged?.Invoke(_currentHealth);

                if (_currentHealth == 0)
                {
                    Services.Instance.GameStateManager.SetCharacterDeadState();
                }
            }
        }

        #endregion

    }
}
