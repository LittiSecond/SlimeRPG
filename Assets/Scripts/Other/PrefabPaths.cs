using System.Collections.Generic;


namespace SlimeRpg
{
    public static class PrefabPaths
    {
        public static readonly Dictionary<string, string> Paths = new Dictionary<string, string>()
        {
            {
                "PlayerCharacter", "Prefabs/PlayerCharacter"
            },
            {
                "Ground1", "Prefabs/Ground/Ground1"
            },
            {
                "Ground2", "Prefabs/Ground/Ground2"
            }
        };
    }
}
