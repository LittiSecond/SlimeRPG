using System;
using UnityEngine;
using SlimeRpg.Ui;


namespace SlimeRpg
{
    public sealed class UiManager
    {
        #region Fields

        private UiIngameScreen _inGameScreen;

        private bool _haveIngameScreen;

        #endregion


        //#region ClassLifeCycles

        //public UiManager()
        //{

        //}

        //#endregion


        #region Methods

        public void SetCharacterDeadState()
        {
            if (!_haveIngameScreen)
            {
                GetUiIngameScreen();
            }
            _inGameScreen.ShowRebornPanel();
        }

        public void SetGameState()
        {
            if (!_haveIngameScreen)
            {
                GetUiIngameScreen();
            }
            _inGameScreen.HideRebornPanel();
        }

        private void GetUiIngameScreen()
        {
            _inGameScreen = Services.Instance.Factory.GetUiIngameScreen();
            _haveIngameScreen = true;
        }

        #endregion


    }
}
