using System;
using UnityEngine;


namespace SlimeRpg
{
    public class NpcBaseLogick : PooledObject, IExecutable
    {
        #region Fields

        [SerializeField] private float _speed;
        [SerializeField] private float _selfDestroyXPosition;

        public event Action<NpcBaseLogick> OnDestroy;


        protected bool _isEnabled;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {

        }

        #endregion


        #region Methods

        public virtual void DestroyItSelf()
        {
            _isEnabled = false;
            OnDestroy?.Invoke(this);
            ReturnToPool();
        }

        public virtual void Initialize()
        {
            _isEnabled = true;
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isEnabled)
            {
                if (transform.position.x <= _selfDestroyXPosition)
                {
                    DestroyItSelf();
                }
                else
                {
                    transform.Translate(-_speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
                }
            }
        }

        #endregion
    }
}
