using UnityEngine;
using UnityEngine.UI;


namespace SlimeRpg.Ui
{
    public class UiIngameScreen : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _rebornPanel;
        [SerializeField] private Button _rebornButton;

        #endregion


        #region Properties

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _rebornButton.onClick.AddListener(RebornButtonClick);
            HideRebornPanel();
        }

        #endregion


        #region Methods

        private void RebornButtonClick()
        {
            Services.Instance.GameStateManager.SetIngameState();
        }

        public void ShowRebornPanel()
        {
            _rebornPanel.SetActive(true);
        }

        public void HideRebornPanel()
        {
            _rebornPanel.SetActive(false);
        }


        #endregion

    }
}