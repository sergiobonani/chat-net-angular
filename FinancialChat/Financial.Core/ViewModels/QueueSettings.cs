namespace Financial.Core.ViewModels
{
    public class QueueSettings
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }

        public string RoutingKey { get; set; }
    }
}
