using UnityEngine;


namespace SlimeRpg
{
    [CreateAssetMenu(fileName = "NewSpawnData", menuName = "Resources/SpawnLogickData")]
    public sealed class EnemySpawnLogickData : ScriptableObject
    {
        public Vector3 SpawnPosition;
        [Header("Health boost per step")]
        public int HealthStep;
        [Header("Attack boost per step")]
        public int AttackStep;
        public int StartHealth;
        public int StartAttack;

        public float SpawnInterval;
        [Header("Number of NPC per step")]
        public int Count;
        public float IntervalBetweenSteps;
    }
}
