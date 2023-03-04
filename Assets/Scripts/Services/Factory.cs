using System;
using UnityEngine;
using SlimeRpg.Ui;


namespace SlimeRpg
{
    public sealed class Factory
    {
        #region Fields

        private string SLIME_PREFAB_ID = "Slime";

        private SlimeBody _slimeBody;
        private UiIngameScreen _inGameScreen;
        private Transform _canvasTransform;
        private UiCoinIndicator _uiCoinIndicator;
        private UiUpgradePanel _uiUpgradePanel;

        #endregion


        #region ClassLifeCycles

        public Factory()
        {
            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            _canvasTransform = canvas.transform;
        }

        #endregion


        #region Methods

        public SlimeBody GetSlimeBody()
        {
            if (!_slimeBody)
            {
                GameObject prefab = ResourcesLoader.GetPrefab(SLIME_PREFAB_ID);
                if (prefab)
                {
                    GameObject bodyInstance = GameObject.Instantiate(prefab);
                    if (bodyInstance)
                    {
                        _slimeBody = bodyInstance.GetComponent<SlimeBody>();
                    }
                }
            }

            return _slimeBody;
        }

        public UiIngameScreen GetUiIngameScreen()
        {
            if (_inGameScreen == null)
            {
                _inGameScreen = _canvasTransform.GetComponentInChildren<UiIngameScreen>();
            }

            return _inGameScreen;
        }

        public UiCoinIndicator GetCoinIndicator()
        {
            if (_uiCoinIndicator == null)
            {
                _uiCoinIndicator = _canvasTransform.GetComponentInChildren<UiCoinIndicator>();
            }

            return _uiCoinIndicator;
        }

        public UiUpgradePanel GetUiUpgradePanel()
        {
            if (_uiUpgradePanel == null)
            {
                _uiUpgradePanel = _canvasTransform.GetComponentInChildren<UiUpgradePanel>();
            }

            return _uiUpgradePanel;
        }

        #endregion
    }
}
