using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Dtos
{
    public class BotCommandRequestDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public Guid SenderId { get; set; }
    }
}
