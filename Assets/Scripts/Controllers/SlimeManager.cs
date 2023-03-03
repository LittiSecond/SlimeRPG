namespace SlimeRpg
{
    public sealed class SlimeManager
    {
        #region Fields

        private SlimeBody _slimeBody;

        private bool _isInitialized;

        #endregion


        #region Properties

        #endregion


        #region ClassLifeCycles

        #endregion


        #region Methods

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _slimeBody = Services.Instance.Factory.GetSlimeBody();
            }
        }

        #endregion

    }
}
