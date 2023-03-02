
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
            WorldBuildLogick worldBuildLogick = new WorldBuildLogick();
            WorldBuilder worldBuilder = new WorldBuilder(groundMovementController, worldBuildLogick);

            _executeControllers = new IExecutable[]
            {
                groundMovementController,
                worldBuilder
            };


        }

        #endregion

    }
}
