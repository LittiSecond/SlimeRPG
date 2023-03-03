using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class NpcMeleeAttack : IExecutable
    {
        #region Fields

        private Animator _strikeAnimator;
        private Transform _strikeTransform;
        private Vector3 _startLocalPosition = new Vector3(-0.5f, 1.0f, 0.0f);

        private float _attackInterval = 2.0f;
        private float _timeCounter;

        private int _strike = Animator.StringToHash("Strike");

        private bool _isAttackMode;

        #endregion


        #region ClassLifeCycles

        public NpcMeleeAttack(Transform strikeTransform, NpcMovement npcMovement, Animator fistAnimator )
        {
            _strikeTransform = strikeTransform;
            npcMovement.OnTargetReached += OnTargetReached;
            _strikeAnimator = fistAnimator;
        }

        #endregion


        #region Methods

        public void Initialize()
        {
            _strikeTransform.localPosition = _startLocalPosition;
            _strikeTransform.gameObject.SetActive(false);
            _isAttackMode = false;
        }

        private void StartAttack()
        {
            _strikeAnimator.SetTrigger(_strike);
        }

        private void OnTargetReached()
        {
            _strikeTransform.gameObject.SetActive(true);
            _isAttackMode = true;
            StartAttack();
            _timeCounter = 0.0f;
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            if (_isAttackMode)
            {
                _timeCounter += Time.deltaTime;
                if (_timeCounter >= _attackInterval)
                {
                    StartAttack();
                    _timeCounter = 0.0f;
                }
            }
        }

        #endregion

    }
}
