namespace SlimeRpg
{
    public sealed class GameStateManager
    {
        #region Fields

        private WorldBuilder _worldBuilder;
        private GroundMovementController _groundMovementController;

        #endregion


        #region Methods

        public void SetControllers(WorldBuilder wb, GroundMovementController gmc)
        {
            _worldBuilder = wb;
            _groundMovementController = gmc;
        }

        public void StartGame()
        {
            _worldBuilder.StartWorldBuilding();
            _groundMovementController.StartMovement();
        }

        #endregion
    }
}
