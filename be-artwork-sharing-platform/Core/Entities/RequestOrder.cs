namespace be_artwork_sharing_platform.Core.Entities
{
    public class RequestOrder : BaseEntity<long>
    {
        public string SenderUserName { get; set; }
        public string ReceiverUserName { get; set; }
        public string Text { get; set; }

    }
}
