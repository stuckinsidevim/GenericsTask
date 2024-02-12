namespace GenericsTask
{
    public class ChatMessage
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime TimeStamp { get; set; }
        public int SourceId { get; set; }
    }
}
