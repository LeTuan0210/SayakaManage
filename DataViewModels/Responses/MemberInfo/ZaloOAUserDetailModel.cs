namespace DataViewModels.Responses.MemberInfo
{
    public class UserZaloData
    {
        public string user_id { get; set; }
        public string user_id_by_app { get; set; }
        public string display_name { get; set; }
        public string user_alias { get; set; }
        public bool is_sensitive { get; set; }
        public string user_last_interaction_date { get; set; }
        public bool user_is_follower { get; set; }
        public string avatar { get; set; }
    }
    public class ZaloOAUserDetailModel
    {
        public UserZaloData data { get; set; }
        public int error { get; set; }
        public string message { get; set; }
    }
}
