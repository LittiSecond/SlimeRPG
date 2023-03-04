using System;


namespace SlimeRpg
{
    public sealed class CoinsController
    {
        #region Fields

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
                _uiIndicator.SetValue(_coinCounter);
            }
        }

        public void Initialize()
        {
            _uiIndicator = Services.Instance.Factory.GetCoinIndicator();
            _uiIndicator.SetValue(_coinCounter);
            _isInitialized = true;
        }

        #endregion
    }
}
