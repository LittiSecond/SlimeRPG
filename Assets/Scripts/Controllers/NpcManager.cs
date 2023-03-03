﻿using System;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class NpcManager : IExecutable
    {
        #region Fields

        private readonly List<NpcBaseLogick> _npcOnField;
        private readonly NpcSpawner _npcSpawner;

        private bool _isSpawnEnabled;
        private bool _isNpcLogickEnabled;

        #endregion


        #region ClassLifeCycles

        public NpcManager(GamePlaySettings gps)
        {
            _npcOnField = new List<NpcBaseLogick>();
            _npcSpawner = new NpcSpawner(this, OnDestroyNpc, gps.SpawnLogickData);
        }

        #endregion


        #region Methods


        public void StartNpcSpawn()
        {
            _npcSpawner.StartSpawn();
            _isSpawnEnabled = true;
            _isNpcLogickEnabled = true;
        }

        public void StopNpcSpawn()
        {
            _npcSpawner.StopSpawn();
            _isSpawnEnabled = false;
        }

        public void ClearNpc()
        {
            for (int i = _npcOnField.Count - 1; i >= 0; i--)
            {
                _npcOnField[i].OnDestroy -= OnDestroyNpc;
                _npcOnField[i].DestroyItSelf();
            }
            _npcOnField.Clear();
        }

        public void AddNpc(NpcBaseLogick newNpc)
        {
            _npcOnField.Add(newNpc);
        }

        private void ExecuteNpcLogick()
        {
            for (int i = 0; i < _npcOnField.Count; i++)
            {
                _npcOnField[i].Execute();
            }
        }

        private void OnDestroyNpc(NpcBaseLogick npc)
        {
            _npcOnField.Remove(npc);
            npc.OnDestroy -= OnDestroyNpc;
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isNpcLogickEnabled)
            {
                ExecuteNpcLogick();
            }

            if (_isSpawnEnabled)
            {
                _npcSpawner.Execute();
            }
        }

        #endregion

    }
}