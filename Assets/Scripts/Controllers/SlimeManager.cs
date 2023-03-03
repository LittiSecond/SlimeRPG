using UnityEngine;


namespace SlimeRpg
{
    public sealed class SlimeManager
    {
        #region Fields

        private SlimeBody _slimeBody;
        private Vector3 _slimeSpawnPosition;

        private bool _isInitialized;

        #endregion


        #region ClassLifeCycles

        public SlimeManager(GamePlaySettings gps)
        {
            _slimeSpawnPosition = gps.SlimePosition;
        }

        #endregion


        #region Methods

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                _slimeBody = Services.Instance.Factory.GetSlimeBody();
                _slimeBody.transform.position = _slimeSpawnPosition;
            }
        }

        #endregion

    }
}
