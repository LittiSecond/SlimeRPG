using System;
using UnityEngine;


namespace SlimeRpg
{
    public class NpcBaseLogick : PooledObject, IExecutable, ITakeDamag
    {
        #region Fields

        [SerializeField] private HpIndicator _hpIndicator;
        [SerializeField] private Fist _fist;
        [SerializeField] private Animator _fistAnimator;
        [SerializeField] private float _speed;
        [SerializeField] private float _selfDestroyXPosition;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _attackPower;
        [SerializeField] private int _rewardCost;

        public event Action<NpcBaseLogick> OnDestroy;

        private NpcHealth _npcHealth;
        private NpcMovement _npcMovement;
        private NpcMeleeAttack _meleeAttack;

        private Vector3 _slimePosition;
        private bool _isEnabled;
        private bool _isDestroyed;

        #endregion


        #region UnityMethods

        private  void Awake()
        {
            _npcHealth = new NpcHealth(_maxHealth);
            _npcHealth.OnHealthEnd += OnHealthEnd;
            _npcMovement = new NpcMovement(transform);
            _npcMovement.Speed = _speed;
            _fist.SetAttackPower(_attackPower);
            _meleeAttack = new NpcMeleeAttack(_fist.transform, _npcMovement, _fistAnimator);
        }

        private void Start()
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

        public virtual void Initialize(Vector3 slimePosition)
        {
            _isEnabled = true;
            _isDestroyed = false;
            _slimePosition = slimePosition;
            _npcHealth.ResetHealth();
            _npcMovement.Initialize(_slimePosition);
            _meleeAttack.Initialize();
        }

        private void OnHealthEnd()
        {
            _isDestroyed = true;
        }

        private void DestroyItselfWithReward()
        {
            Services.Instance.CharacterIntermediary.SendReward(_rewardCost);
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
                    _npcMovement.Execute();
                    _meleeAttack.Execute();
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
