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
        [Header("Slime stats")]
        public StatDescriptor AttackStat;
        public StatDescriptor AttackSpeedStat;
        public StatDescriptor HealthStat;

        [Space(20)]
        public float AttackIntervalMultipler;
        public float AttackRange;
        public float BulletSpeed;

    }
}