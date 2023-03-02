using System;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class WorldBuilder : IExecutable
    {
        #region Fields

        private float X_POSITION_REMOVE_GROUND = -10.0f;
        private float X_POSITION_ADD_GROUND = 0.0f;
        private float GROUND_X_SIZE = 10.0f;

        private readonly List<Transform> _groundsInWorld;
        private readonly GroundMovementController _groundMovementController;


        #endregion


        #region ClassLifeCycles

        public WorldBuilder(GroundMovementController gmc)
        {
            _groundMovementController = gmc;
            _groundsInWorld = new List<Transform>();
        }

        #endregion


        #region Methods



        #endregion


        #region IExecutable

        public void Execute()
        {

        }

        #endregion

    }
}
