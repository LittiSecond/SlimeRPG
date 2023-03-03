using UnityEngine;


namespace SlimeRpg
{
    [CreateAssetMenu(fileName = "NewSpawnData", menuName = "Resources/SpawnLogickData")]
    public sealed class EnemySpawnLogickData : ScriptableObject
    {
        public Vector3 SpawnPosition;
        public float SpawnInterval;
    }
}
