using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class Stat : IStatPower
    {
        #region Fields

        private int _baseValue;
        private int _power;
        private int _level;
        private int _upgradeCost;
        private int _upgradeStep;

        #endregion


        #region Properties

        public int Power { get => _power; }
        public int UpgradeCost { get => _upgradeCost; }
        public int Level { get => _level; }
        #endregion


        #region ClassLifeCycles

        public Stat(StatDescriptor descriptor)
        {
            _baseValue = descriptor.BaseValue;
            _upgradeCost = descriptor.UpgradeCost;
            _upgradeStep = descriptor.UpgradeStep;
            _power = _baseValue;
            _level = 1;
        }

        #endregion


        #region Methods

        public void Upgrade()
        {
            _power += _upgradeStep;
            _level++;
        }

        #endregion
    }
}
