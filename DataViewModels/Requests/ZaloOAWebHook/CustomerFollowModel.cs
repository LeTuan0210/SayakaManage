namespace DataViewModels.Requests
{
    public class CustomerFollowEvent
    {
        public FollowerUserEvent follower { get; set; }
        public string user_id_by_app { get; set; }
        public string event_name { get; set; }
    }
    public class FollowerUserEvent
    {
        public string id { get; set; }
    }
}
