using Financial.Core.ViewModels;

namespace FinancialChat.Consumer.DTOs
{
    public class AppSettings
    {
        public string ChatApiUrl { get; set; }
        public string SendMethod { get; set; }

        public int IntervalWorkerActive { get; set; }

        public QueueSettings QueueSettings { get; set; }
    }
}
