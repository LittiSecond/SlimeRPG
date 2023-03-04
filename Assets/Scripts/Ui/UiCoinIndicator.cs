using UnityEngine;
using UnityEngine.UI;


namespace SlimeRpg.Ui
{
    public class UiCoinIndicator : MonoBehaviour
    {

        #region Fields

        [SerializeField] private Text _text;

        #endregion


        #region Methods

        public void SetValue(int amount)
        {
            _text.text = amount.ToString();
        }

        #endregion

    }
}