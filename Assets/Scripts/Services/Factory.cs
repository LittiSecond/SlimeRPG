using System;
using UnityEngine;


namespace SlimeRpg
{
    public sealed class Factory
    {
        #region Fields

        private string SLIME_PREFAB_ID = "Slime";

        private SlimeBody _slimeBody;

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

        #endregion
    }
}
