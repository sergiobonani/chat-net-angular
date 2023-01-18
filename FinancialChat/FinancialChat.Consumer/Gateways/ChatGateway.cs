using Financial.Core.Gateways;
using FinancialChat.Consumer.DTOs;
using FinancialChat.Consumer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Consumer.Gateways
{
    public class ChatGateway : BaseGateway<ChatGateway>, IChatGateway
    {
        public ChatGateway(ILogger<ChatGateway> logger) : base(logger)
        {
        }

        public async Task SendMessageAsyc(string url, MessageRequestDto request)
        {            
            await PostRequest(url, request);
        }
    }
}
