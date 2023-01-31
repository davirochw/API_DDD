using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceMessage
    {
        Task Add(Message Objeto);
        Task Update(Message Objeto);
        Task<List<Message>> ListMessageActive();
    }
}
