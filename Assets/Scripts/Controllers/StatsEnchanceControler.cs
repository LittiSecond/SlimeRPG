using System;
using UnityEngine;
using SlimeRpg.Ui;

namespace SlimeRpg
{
    public sealed class StatsEnchanceControler
    {
        #region Fields

        private readonly Stat _attackStat;
        private readonly Stat _attackSpeedStat;
        private readonly Stat _healthStat;
        private readonly CoinsController _coinsController;

        private UiUpgradePanel _uiUpgradePanel;

        private bool _isInitialized;

        #endregion


        #region ClassLifeCycles

        public StatsEnchanceControler(Stat attack, Stat attackSpeed, Stat health, CoinsController coinsController)
        {
            _attackStat = attack;
            _attackSpeedStat = attackSpeed;
            _healthStat = health;
            _coinsController = coinsController;
        }

        #endregion


        #region Methods

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _uiUpgradePanel = Services.Instance.Factory.GetUiUpgradePanel();
                _uiUpgradePanel.OnAttackEnchanceClick += EnchanceAttack;
                _uiUpgradePanel.OnAttackSpeedEnchanceClick += EnchanceAttackSpeed;
                _uiUpgradePanel.OnHealthEnchanceClick += EnchanceHealth;
                _uiUpgradePanel.SetAttackValue(_attackStat.Power);
                _uiUpgradePanel.SetAttackSpeedValue(_attackSpeedStat.Power);
                _uiUpgradePanel.SetHealthValue(_healthStat.Power);

                _isInitialized = true;
            }
        }

        private void EnchanceAttack()
        {
            if (_isInitialized)
            {
                int enchanceCost = _attackStat.UpgradeCost;
                if (_coinsController.SpendCoins(enchanceCost))
                {
                    _attackStat.Upgrade();
                }
                _uiUpgradePanel.SetAttackValue(_attackStat.Power);
            }
        }

        private void EnchanceAttackSpeed()
        {
            if (_isInitialized)
            {
                int enchanceCost = _attackSpeedStat.UpgradeCost;
                if (_coinsController.SpendCoins(enchanceCost))
                {
                    _attackSpeedStat.Upgrade();
                }
                _uiUpgradePanel.SetAttackSpeedValue(_attackSpeedStat.Power);
            }
        }

        private void EnchanceHealth()
        {
            if (_isInitialized)
            {
                int enchanceCost = _healthStat.UpgradeCost;
                if (_coinsController.SpendCoins(enchanceCost))
                {
                    _healthStat.Upgrade();
                }
                _uiUpgradePanel.SetHealthValue(_healthStat.Power);
            }
        }


        #endregion

    }
}
