
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

            SlimeManager slimeManager = new SlimeManager(gamePlaySettings);

            NpcManager npcManager = new NpcManager(gamePlaySettings, groundMovementController);

            SlimeAttack slimeAttack = new SlimeAttack(gamePlaySettings, npcManager);
            SlimeHealth slimeHealth = new SlimeHealth(gamePlaySettings);

            _executeControllers = new IExecutable[]
            {
                groundMovementController,
                worldBuilder,
                npcManager,
                slimeAttack
            };

            Services.Instance.GameStateManager.SetControllers(worldBuilder, groundMovementController, slimeManager, 
                npcManager, slimeAttack, slimeHealth);
        }

        #endregion

    }
}
