namespace DataViewModels.Requests
{
    public class TextMessageModel
    {
        public Recipient recipient { get; set; } = new Recipient();
        public Message message { get; set; } = new Message();
    }
    public class Message
    {
        public string text { get; set; }
    }

    public class Recipient
    {
        public string user_id { get; set; }
        public string group_id { get; set; }
    }
}
