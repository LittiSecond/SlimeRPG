using System;


namespace SlimeRpg
{
    public sealed class CoinsController
    {
        #region Fields


        public event Action<int> OnCashChanged;

        private Ui.UiCoinIndicator _uiIndicator;

        private int _coinCounter;

        private bool _isInitialized;

        #endregion


        #region ClassLifeCycles

        #endregion


        #region Methods

        public void AddCoins(int amount)
        {
            if (_isInitialized)
            {
                _coinCounter += amount;
                OnCashChanged?.Invoke(_coinCounter);
                _uiIndicator.SetValue(_coinCounter);
            }
        }

        public void Initialize()
        {
            _uiIndicator = Services.Instance.Factory.GetCoinIndicator();
            _uiIndicator.SetValue(_coinCounter);
            _isInitialized = true;
        }

        public bool SpendCoins(int amount)
        {
            bool isSpended = false;
            if (amount <= _coinCounter)
            {
                _coinCounter -= amount;
                OnCashChanged?.Invoke(_coinCounter);
                _uiIndicator.SetValue(_coinCounter);
                isSpended = true;
            }
            return isSpended;
        }

        #endregion
    }
}
