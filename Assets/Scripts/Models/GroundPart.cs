namespace SlimeRpg
{
    public sealed class GroundPart : PooledObject
    {
        public void DestroyItself()
        {
            ReturnToPool();
        }
    }
}
