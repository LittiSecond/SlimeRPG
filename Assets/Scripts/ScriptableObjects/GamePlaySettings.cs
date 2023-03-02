using UnityEngine;


namespace SlimeRpg
{
    [CreateAssetMenu(fileName = "NewSettings", menuName = "Resources/GamePlaySettings")]
    public sealed class GamePlaySettings : ScriptableObject
    {
        public float GroundSpeed;
        public float ChangeSpeedDuration;

    }
}