using Entities.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceMessage
    {
        Task Add(Message Objeto);
        Task Update(Message Objeto);
        Task<List<Message>> ListMessageActive();
    }
}
