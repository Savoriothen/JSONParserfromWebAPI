namespace JSONParserfromWebAPI.JsonTypes
{
    internal class Broadcast
    {
        #region Instance Properties

        public bool is_repeat { get; set; }
        public bool is_blanked { get; set; }
        public string pid { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int duration { get; set; }
        public Programme programme { get; set; }
        #endregion
    }

}
