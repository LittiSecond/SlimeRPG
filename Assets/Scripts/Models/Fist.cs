using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class Fist : MonoBehaviour 
    {
        #region Fields

        private int _attackPower;

        #endregion

        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == (int)SceneLayers.Player)
            {
                ITakeDamag damagReceiver = other.GetComponent<ITakeDamag>();
                damagReceiver?.TakeDamage(_attackPower);
            }
        }

        #endregion


        #region Methods

        public void SetAttackPower(int power)
        {
            _attackPower = power;
        }

        #endregion

    }
}
