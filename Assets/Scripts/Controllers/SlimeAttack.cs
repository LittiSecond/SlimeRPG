using System;
using System.Collections.Generic;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class SlimeAttack : IExecutable
    {
        #region PrivateData

        private enum AttackState
        { 
            None            = 0,
            SearchTarget    = 1,
            Loading         = 2
        }

        #endregion


        #region Fields

        private const string BULLET_PREFAB_ID = "Bullet1";

        private Vector3 _bulletStartPosition;
        private readonly INpcLocator _npcLocator;
        private float _slimeXPosition;
        private int _attackPower;
        private float _bulletSpeed;
        private float _range;

        private float _attackSpeed;
        private float _intervalMultipler;

        private float _loadInterval;
        private float _timeCounter;

        private AttackState _state;

        #endregion


        #region ClassLifeCycles

        public SlimeAttack(GamePlaySettings gps, INpcLocator locator)
        {
            _slimeXPosition = gps.SlimePosition.x;
            _attackPower = gps.BaseAttackPower;
            _bulletSpeed = gps.BulletSpeed;
            _range = gps.AttackRange;
            _attackSpeed = gps.BaseAttackSpeed;
            _intervalMultipler = gps.AttackIntervalMultipler;

            _npcLocator = locator;
        }

        #endregion


        #region Methods

        public void On()
        {
            if (_state == AttackState.None)
            {
                _state = AttackState.SearchTarget;
                LoadBulletStartPosition();
            }
        }

        public void Off()
        {
            _state = AttackState.None;
        }

        private void SearchTarget()
        {
            Vector3? targetPosition = _npcLocator.GetNearestNpcPosition();
            if (targetPosition != null)
            {
                if ((targetPosition.Value.x - _slimeXPosition) <= _range)
                {
                    Attack(targetPosition.Value);
                    StartLoading();
                }
            }
        }

        private void Loading()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter >= _loadInterval)
            {
                _state = AttackState.SearchTarget;
            }
        }

        private void Attack(Vector3 targetPosition)
        {
            PooledObject pooledObject = Services.Instance.ObjectPool.GetObjectOfType(BULLET_PREFAB_ID);
            Bullet bullet = pooledObject as Bullet;
            bullet.SetPosition(_bulletStartPosition);
            bullet.Kick(targetPosition, _attackPower, _bulletSpeed, SceneLayers.Npc);
        }

        private void StartLoading()
        {
            _timeCounter = 0.0f;
            _state = AttackState.Loading;
            CalculateLoadInterval();
        }

        private void CalculateLoadInterval()
        {
            _loadInterval = 1 / _attackSpeed * _intervalMultipler;
        }

        private void LoadBulletStartPosition()
        {
            SlimeBody body = Services.Instance.Factory.GetSlimeBody();
            _bulletStartPosition = body.GetBulletStartPoint().position;
        }

        #endregion


        #region IExecutable

        public void Execute()
        {
            switch (_state)
            {
                case AttackState.SearchTarget:
                    SearchTarget();
                    break;
                case AttackState.Loading:
                    Loading();
                    break;
            }
        }

        #endregion
    }
}
