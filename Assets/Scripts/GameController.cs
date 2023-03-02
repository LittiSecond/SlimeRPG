using UnityEngine;


namespace SlimeRpg
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GamePlaySettings DefaultGamePlaySettings;
        private Controllers _controllers;

        #endregion


        #region UnityMethods

        private void Start()
        {


            _controllers = new Controllers(DefaultGamePlaySettings);

        }


        private void Update()
        {
            for (int i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }

        #endregion

    }
}