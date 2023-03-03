using System;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class WorldBuilder : IExecutable
    {
        #region Fields

        private const float X_POSITION_REMOVE_GROUND = -10.0f;
        private const float X_POSITION_ADD_GROUND = 0.0f;
        private const float GROUND_X_SIZE = 10.0f;
        private const float FIRST_GROUND_X_POZITION = 1.0f;

        private readonly List<GroundPart> _groundsInWorld;
        private readonly GroundMovementController _groundMovementController;
        private readonly WorldBuildLogick _worldBuildLogick;

        private bool _isEnabled;

        #endregion


        #region ClassLifeCycles

        public WorldBuilder(GroundMovementController gmc, WorldBuildLogick wbl)
        {
            _groundsInWorld = new List<GroundPart>();
            _groundMovementController = gmc;
            _worldBuildLogick = wbl;
        }

        #endregion


        #region Methods

        public void StartWorldBuilding()
        {
            BuildGroundPart(FIRST_GROUND_X_POZITION);
            if (_groundsInWorld.Count > 0)
            {
                _isEnabled = true;
            }
        }

        private void BuildGroundPart(float xPosition)
        {
            string id = _worldBuildLogick.GetNextGroundPartID();
            PooledObject obj = Services.Instance.ObjectPool.GetObjectOfType(id);
            if (obj != null)
            {
                GroundPart part = obj as GroundPart;
                if (part != null)
                {
                    Vector3 position = Vector3.zero;
                    position.x = xPosition;
                    Transform transform = obj.transform;
                    transform.position = position;
                    _groundsInWorld.Add(part);
                    _groundMovementController.AddGroundPart(transform);
                }
            }

        }

        private void RemoveFirstGroundPart()
        {
            if (_groundsInWorld.Count > 0)
            {
                GroundPart groundPart = _groundsInWorld[0];
                _groundsInWorld.RemoveAt(0);
                _groundMovementController.RemoveGroundPart(groundPart.transform);
                groundPart.DestroyItself();
            }
        }


        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isEnabled)
            {
                if (_groundsInWorld.Count > 0)
                {
                    GroundPart groundPart = _groundsInWorld[0];
                    if (groundPart.transform.position.x <= X_POSITION_REMOVE_GROUND)
                    {
                        RemoveFirstGroundPart();
                    }

                    groundPart = _groundsInWorld[_groundsInWorld.Count - 1];
                    float xPosition = groundPart.transform.position.x;
                    if (xPosition <= X_POSITION_ADD_GROUND)
                    {
                        BuildGroundPart(xPosition + GROUND_X_SIZE);
                    }
                }
            }
        }

        #endregion

    }
}
