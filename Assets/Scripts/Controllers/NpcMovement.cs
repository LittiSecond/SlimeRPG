using UnityEngine;


namespace SlimeRpg
{
    public sealed class NpcMovement : IExecutable
    {
        #region Fields

        private Transform _transform;

        private float _speed;

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



        #endregion


        #region IExecutable

        public void Execute()
        {
            _transform.Translate(-_speed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        #endregion
    }
}
