using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class HpIndicator : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _barTransform;
        private IHealth _healthSource;
        private float _maxXScale;
        private int _maxHealth;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _maxXScale = _barTransform.localScale.x;
        }

        #endregion


        #region Methods

        public void SetIHealth(IHealth health)
        {
            if (_healthSource == null)
            {
                _healthSource = health;
                _healthSource.OnHealthChanged += SetValue;
                ResetValues();
            }
        }

        private void SetValue(int newHealth)
        {
            if (_maxHealth > 0.0f)
            {
                float scale = (float)newHealth / _maxHealth;
                Vector3 localScale = _barTransform.localScale;
                localScale.x = scale * _maxXScale;
                _barTransform.localScale = localScale;
            }
        }

        public void ResetValues()
        {
            if (_healthSource != null)
            {
                _maxHealth = _healthSource.MaxHealth;
                SetValue(_healthSource.Health);
            }
        }

        #endregion


    }
}
