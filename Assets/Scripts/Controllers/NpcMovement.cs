using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class NpcMovement : IExecutable
    {
        #region Fields

        private const float STOP_SQR_DISTANCE = 0.0625f;

        public event Action OnTargetReached;

        private readonly Transform _transform;
        private Vector3 _slimePosition;

        private float _speed;

        private bool _isMovement;

        #endregion

        #region Properties

        public float Speed { set => _speed = value; }

        #endregion


        #region ClassLifeCycles

        public NpcMovement(Transform t)
        {
            _transform = t;
        }

        #endregion


        #region Methods

        public void Initialize(Vector3 slimePosition)
        {
            _slimePosition = slimePosition;
            _isMovement = true;
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isMovement)
            {
                _transform.Translate(-_speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                if ( (_slimePosition - _transform.position).sqrMagnitude <= STOP_SQR_DISTANCE )
                {
                    OnTargetReached?.Invoke();
                    _isMovement = false;
                }
            }
        }

        #endregion
    }
}
