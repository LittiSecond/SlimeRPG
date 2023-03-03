using UnityEngine;


namespace SlimeRpg
{
    public sealed class SlimeBody : MonoBehaviour, ITakeDamag
    {
        #region Fields

        [SerializeField] private Transform _bulletStartPoint;
        [SerializeField] private HpIndicator _hpIndicator;

        private ITakeDamag _damagReceiver;

        #endregion


        #region Methods

        public Transform GetBulletStartPoint()
        {
            return _bulletStartPoint;
        }

        public HpIndicator GetHpIndicator()
        {
            return _hpIndicator;
        }

        public void SetTekerDamag(ITakeDamag takeDamag)
        {
            _damagReceiver = takeDamag;
        }

        #endregion


        #region ITakeDamag

        public void TakeDamage(int amount)
        {
            _damagReceiver?.TakeDamage(amount);
        }

        #endregion
    }
}
