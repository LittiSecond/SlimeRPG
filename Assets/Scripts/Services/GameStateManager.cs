using UnityEngine;


namespace SlimeRpg
{
    public sealed class GameStateManager
    {
        #region Fields

        private WorldBuilder _worldBuilder;
        private GroundMovementController _groundMovementController;
        private SlimeManager _slimeManager;
        private NpcManager _npcManager;
        private SlimeAttack _slimeAttack;
        private SlimeHealth _slimeHealth;

        #endregion


        #region Methods

        public void SetControllers(WorldBuilder wb, GroundMovementController gmc, SlimeManager sm, 
            NpcManager nm, SlimeAttack sa, SlimeHealth sh)
        {
            _worldBuilder = wb;
            _groundMovementController = gmc;
            _slimeManager = sm;
            _npcManager = nm;
            _slimeAttack = sa;
            _slimeHealth = sh;
        }

        public void StartGame()
        {
            _worldBuilder.StartWorldBuilding();
            _groundMovementController.StartMovement();
            _slimeManager.Initialize();
            _slimeHealth.Initialize();
            _npcManager.StartNpcSpawn();
            _slimeAttack.On();
        }

        public void SetCharacterDeadState()
        {
            Time.timeScale = 0.0f;
            Services.Instance.UiManager.SetCharacterDeadState();
            _npcManager.StopNpcSpawn();
        }

        public void SetIngameState()
        {
            Time.timeScale = 1.0f;
            Services.Instance.UiManager.SetGameState();
            _npcManager.ClearNpc();
            _npcManager.StartNpcSpawn();
            _slimeHealth.Initialize();
        }





        #endregion
    }
}
