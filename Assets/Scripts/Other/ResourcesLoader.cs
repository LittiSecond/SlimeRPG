using UnityEngine;


namespace SlimeRpg
{
    public static class ResourcesLoader
    {
        public static GameObject GetPrefab(string prefabID)
        {
            GameObject go = null;

            if (PrefabPaths.Paths.ContainsKey(prefabID))
            {
                go = Resources.Load<GameObject>(PrefabPaths.Paths[prefabID]);
            }
            return go;
        }
    }
}
