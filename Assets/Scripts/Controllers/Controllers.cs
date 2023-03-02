
namespace SlimeRpg
{
    public sealed class Controllers
    {
        #region Fields

        private readonly IExecutable[] _executeControllers;

        #endregion


        #region Properties
        public int Length => _executeControllers.Length;
        public IExecutable this[int index] => _executeControllers[index];

        #endregion


        #region ClassLifeCycles

        public Controllers(GamePlaySettings gamePlaySettings)
        {
            GroundMovementController groundMovementController = new GroundMovementController(gamePlaySettings);
            WorldBuilder worldBuilder = new WorldBuilder(groundMovementController);

            _executeControllers = new IExecutable[]
            {
                groundMovementController,
                worldBuilder
            };


        }

        #endregion

    }
}
