using System;
using UnityEngine;
using UnityEngine.UI;


namespace SlimeRpg.Ui
{
    public class UiUpgradePanel : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Button _attackEnhanceButton;
        [SerializeField] private Button _attackSpeedEnhanceButton;
        [SerializeField] private Button _healthEnhanceButton;
        [SerializeField] private Text _attackValue;
        [SerializeField] private Text _attackSpeedValue;
        [SerializeField] private Text _healthValue;

        public event Action OnAttackEnchanceClick;
        public event Action OnAttackSpeedEnchanceClick;
        public event Action OnHealthEnchanceClick;

        #endregion


        #region Properties

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _attackEnhanceButton.onClick.AddListener(AttackEnchanceClick);
            _attackSpeedEnhanceButton.onClick.AddListener(AttackSpeedEnchanceClick);
            _healthEnhanceButton.onClick.AddListener(HealthEnchanceClick);
        }

        #endregion


        #region Methods

        private void AttackEnchanceClick()
        {
            OnAttackEnchanceClick?.Invoke();
        }

        private void AttackSpeedEnchanceClick()
        {
            OnAttackSpeedEnchanceClick?.Invoke();
        }

        private void HealthEnchanceClick()
        {
            OnHealthEnchanceClick?.Invoke();
        }

        public void SetAttackValue(int value)
        {
            _attackValue.text = value.ToString();
        }

        public void SetAttackSpeedValue(int value)
        {
            _attackSpeedValue.text = value.ToString();
        }

        public void SetHealthValue(int value)
        {
            _healthValue.text = value.ToString();
        }

        #endregion


    }
}