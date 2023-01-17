using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Application.ViewModels
{
    public class AppSettings
    {
        public string UrlBot { get; set; }
        public List<AllowedBotCommands> AllowedBotCommands { get; set;}
    }

    public class AllowedBotCommands
    {
        public string BaseUrl { get; set; }
        public string Command { get; set; }
    }
}
