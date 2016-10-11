namespace JSONParserfromWebAPI.JsonTypes
{
    internal class Programme2
    {
        #region Instance Properties

        public string type { get; set; }
        public string pid { get; set; }
        public string title { get; set; }
        public int? position { get; set; }
        public Image2 image { get; set; }
        public int? expected_child_count { get; set; }
        public string first_broadcast_date { get; set; }
        public Ownership2 ownership { get; set; }
        public Programme3 programme { get; set; }
        #endregion
    }

}
