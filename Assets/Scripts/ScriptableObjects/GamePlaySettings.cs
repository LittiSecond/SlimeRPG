using UnityEngine;


namespace SlimeRpg
{
    [CreateAssetMenu(fileName = "NewSettings", menuName = "Resources/GamePlaySettings")]
    public sealed class GamePlaySettings : ScriptableObject
    {
        public float GroundSpeed;
        public float ChangeSpeedDuration;
        public EnemySpawnLogickData SpawnLogickData;
        public Vector3 SlimePosition;
        [Header("Slime stats: base values")]
        public int BaseSlimeHealth;
        public int BaseAttackPower;
        public int BaseAttackSpeed;
        [Space(20)]
        public float AttackIntervalMultipler;
        public float AttackRange;
        public float BulletSpeed;

    }
}