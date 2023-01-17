using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Application.Interfaces.UseCases
{
    public interface IBaseUseCase<T>
    {
        Task ExecuteAsync(T entity);
    }
}
