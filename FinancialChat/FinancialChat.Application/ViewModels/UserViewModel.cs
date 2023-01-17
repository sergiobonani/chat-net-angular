using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Application.ViewModels
{
    public class UserViewModel
    {
        public string ConnectionId { get; set; }

        public DateTime ConnectionDate { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
