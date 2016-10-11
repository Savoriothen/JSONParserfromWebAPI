namespace JSONParserfromWebAPI.JsonTypes
{
    internal class Programme3
    {
        #region Instance Properties

        public string type { get; set; }
        public string pid { get; set; }
        public string title { get; set; }
        public object position { get; set; }
        public Image3 image { get; set; }
        public object expected_child_count { get; set; }
        public string first_broadcast_date { get; set; }
        public Ownership3 ownership { get; set; }
        #endregion
    }

}
