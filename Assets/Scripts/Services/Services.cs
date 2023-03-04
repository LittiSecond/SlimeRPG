using System;


namespace SlimeRpg
{
    public sealed class Services
    {
        #region Fields

        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        #endregion


        #region ClassLifeCycles

        public Services()
        {
            Initialize();
        }

        #endregion


        #region Properties

        public static Services Instance => _instance.Value;
        public ObjectPool ObjectPool { get; private set; }
        public GameStateManager GameStateManager { get; private set; }
        public Factory Factory { get; private set; }
        public UiManager UiManager { get; private set; }
        public CharacterIntermediary CharacterIntermediary { get; private set; }

        #endregion


        #region Methods

        private void Initialize()
        {
            ObjectPool = new ObjectPool();
            GameStateManager = new GameStateManager();
            Factory = new Factory();
            UiManager = new UiManager();
            CharacterIntermediary = new CharacterIntermediary();
        }

        #endregion
    }
}
