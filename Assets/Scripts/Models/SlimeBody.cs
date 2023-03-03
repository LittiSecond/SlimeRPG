using UnityEngine;


namespace SlimeRpg
{
    public sealed class SlimeBody : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _bulletStartPoint;

        #endregion


        #region Methods

        public Transform GetBulletStartPoint()
        {
            return _bulletStartPoint;
        }

        #endregion


    }
}
