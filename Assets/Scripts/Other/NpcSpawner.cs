using UnityEngine;
using System;
using System.Collections.Generic;


namespace SlimeRpg
{
    public sealed class NpcSpawner : IExecutable
    {

        #region Fields

        private const string ENEMY_TYPE = "Enemy1";

        private readonly NpcManager _npcManager;
        private EnemySpawnLogickData _spawnLogickData;

        private Action<NpcBaseLogick> _onDestroyListener;
        private Vector3 _slimePosition;
        private float _timeCounter;


        private bool _isEnabled;

        #endregion


        #region ClassLifeCycles

        public NpcSpawner(NpcManager nm, Action<NpcBaseLogick> onDestroyListener, GamePlaySettings gps)
        {
            _npcManager = nm;
            _spawnLogickData = gps.SpawnLogickData;
            _onDestroyListener = onDestroyListener;
            _slimePosition = gps.SlimePosition;
        }

        #endregion


        #region Methods

        public void StartSpawn()
        {
            _timeCounter = 0.0f;
            _isEnabled = true;
        }

        public void StopSpawn()
        {
            _isEnabled = false;
        }

        private void SpawnNpc()
        {
            PooledObject obj = Services.Instance.ObjectPool.GetObjectOfType(ENEMY_TYPE);
            if (obj != null)
            {
                NpcBaseLogick npc = obj as NpcBaseLogick;
                if (npc != null)
                {
                    npc.transform.position = _spawnLogickData.SpawnPosition;
                    npc.OnDestroy += _onDestroyListener;
                    _npcManager.AddNpc(npc);
                    npc.Initialize(_slimePosition);
                }
            }
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isEnabled)
            {
                _timeCounter += Time.deltaTime;
                if (_timeCounter >= _spawnLogickData.SpawnInterval)
                {
                    _timeCounter = 0.0f;
                    SpawnNpc();
                }

            }
        }

        #endregion
    }
}
