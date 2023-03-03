using System;
using UnityEngine;


namespace SlimeRpg
{
    public class NpcBaseLogick : PooledObject, IExecutable, ITakeDamag
    {
        #region Fields

        [SerializeField] private HpIndicator _hpIndicator;
        [SerializeField] private float _speed;
        [SerializeField] private float _selfDestroyXPosition;
        [SerializeField] private int _maxHealth;

        public event Action<NpcBaseLogick> OnDestroy;

        private NpcHealth _npcHealth;

        protected bool _isEnabled;
        private bool _isDestroyed;

        #endregion


        #region UnityMethods

        protected virtual void Awake()
        {
            _npcHealth = new NpcHealth(_maxHealth);
            _npcHealth.OnHealthEnd += OnHealthEnd;
        }

        protected virtual void Start()
        {
            _hpIndicator.SetIHealth(_npcHealth);
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
            _isDestroyed = false;
            _npcHealth.ResetHealth();
        }

        private void OnHealthEnd()
        {
            _isDestroyed = true;
        }

        private void DestroyItselfWithReward()
        {

            DestroyItSelf();
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isDestroyed)
            {
                DestroyItselfWithReward();
                _isDestroyed = false;
            }

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


        #region ITakeDamag

        public void TakeDamage(int amount)
        {
            _npcHealth.TakeDamage(amount);
        }

        #endregion
    }
}
