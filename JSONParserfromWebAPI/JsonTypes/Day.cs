using System.Collections.Generic;

namespace JSONParserfromWebAPI.JsonTypes
{
    internal class Day
    {
        #region Instance Properties
        public string date { get; set; }
        public int has_next { get; set; }
        public int has_previous { get; set; }
        public List<Broadcast> broadcasts { get; set; }
        #endregion
    }

}
