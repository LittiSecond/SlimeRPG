using System;
using UnityEngine;


namespace SlimeRpg
{
    public class Bullet : PooledObject
    {
        #region Fields

        [SerializeField] private Rigidbody _rigidbody;

        private float _speed;
        private int _power;
        private SceneLayers _targetLayer;

        #endregion


        #region UnityMethods

        private void OnCollisionEnter(Collision collision)
        {
            int otherLayer = collision.gameObject.layer;
            if (otherLayer == (int)SceneLayers.Ground)
            {
                DestroyItself();
            }
            else if (otherLayer == (int)_targetLayer)
            {
                ITakeDamag damagReceiver = collision.gameObject.GetComponent<ITakeDamag>();
                if (damagReceiver != null)
                {
                    damagReceiver.TakeDamage(_power);
                }
                DestroyItself();
            }

        }

        #endregion


        #region Methods

        public void Kick(Vector3 worldTargetPosition,  int power, float speed, SceneLayers targetLayer )
        {
            _power = power;
            _speed = speed;
            _targetLayer = targetLayer;
            Vector3 newVelosity = CalculateVelosity(worldTargetPosition);
            _rigidbody.AddForce(newVelosity, ForceMode.Impulse);
        }

        public void DestroyItself()
        {
            _rigidbody.velocity = Vector3.zero;
            ReturnToPool();
        }

        private Vector3 CalculateVelosity(Vector3 worldTargetPosition)
        {
            Vector3 direction = worldTargetPosition - transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            return direction * _speed;
        }

        #endregion
    }
}
