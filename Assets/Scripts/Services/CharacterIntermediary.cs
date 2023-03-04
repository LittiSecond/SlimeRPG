namespace SlimeRpg
{
    public sealed class CharacterIntermediary
    {
        #region Fields

        private CoinsController _coinsController;

        #endregion


        #region Properties

        #endregion


        #region ClassLifeCycles

        #endregion


        #region Methods

        public void SetControllers(CoinsController cc)
        {
            _coinsController = cc;
        }

        public void SendReward(int amount)
        {
            if (_coinsController != null)
            {
                _coinsController.AddCoins(amount);
            }
        }

        #endregion
    }
}
