using System;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class GroundMovementController : IExecutable
    {

        #region Fields

        private readonly List<Transform> _grounds;

        private float _normalSpeed;
        private float _changeSpeedDuration;
        private float _currentSpeed;
        private float _acceleration;

        private bool _shouldMove;
        private bool _shouldChangeSpeed;

        #endregion


        #region ClassLifeCycles

        public GroundMovementController(GamePlaySettings gps)
        {
            _normalSpeed = gps.GroundSpeed;
            _changeSpeedDuration = gps.ChangeSpeedDuration;
            _grounds = new List<Transform>();
            _acceleration = _normalSpeed / _changeSpeedDuration;
        }

        #endregion


        #region Methods

        public void AddGroundPart(Transform groundPart)
        {
            _grounds.Add(groundPart);
        }

        public void RemoveGroundPart(Transform groundPart)
        {
            _grounds.Remove(groundPart);
        }

        public void StartMovement()
        {
            //if (_currentSpeed < _normalSpeed)
            //{
            //    if (_acceleration < 0.0f)
            //    {
            //        _acceleration *= -1.0f;
            //    }
            //    _shouldChangeSpeed = true;
            //    _shouldMove = true;
            //}
            _currentSpeed = _normalSpeed;
            _shouldMove = true;
        }

        public void StopMovement()
        {
            //if (_currentSpeed > 0)
            //{
            //    if (_acceleration > 0.0f)
            //    {
            //        _acceleration *= -1.0f;
            //    }
            //    _shouldChangeSpeed = true;
            //}
            _currentSpeed = 0.0f;
            _shouldMove = false;
        }

        private void MoveGrounds()
        {
            float xShift = -_currentSpeed * Time.deltaTime;

            for (int i = 0; i < _grounds.Count; i++)
            {
                _grounds[i].Translate(xShift, 0.0f, 0.0f, Space.World);
            }
        }

        private void ChangeSpeedLogick()
        {
            _currentSpeed += _acceleration * Time.deltaTime;
            if (_currentSpeed > _normalSpeed)
            {
                _currentSpeed = _normalSpeed;
                _shouldChangeSpeed = false;
            }
            else if (_currentSpeed < 0.0f)
            {
                _currentSpeed = 0.0f;
                _shouldChangeSpeed = false;
                _shouldMove = false;
            }
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_shouldChangeSpeed)
            {
                ChangeSpeedLogick();
            }

            if (_shouldMove)
            {
                MoveGrounds();
            }
        }

        #endregion
    }
}
