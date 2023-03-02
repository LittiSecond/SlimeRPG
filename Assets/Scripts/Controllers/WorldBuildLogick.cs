namespace SlimeRpg
{
    public sealed class WorldBuildLogick
    {
        #region Fields

        private string[] _groundIDs = new string[]
            { "Ground1", "Ground2" };

        private int _nextIndex;

        #endregion


        #region Methods

        public string GetNextGroundPartID()
        {
            string next = _groundIDs[_nextIndex];
            _nextIndex++;
            if (_nextIndex >= _groundIDs.Length)
            {
                _nextIndex = 0;
            }

            return next;
        }

        #endregion
    }
}
