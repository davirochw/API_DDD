using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;

        public ServiceMessage(IMessage iMessage)
        {
            _IMessage = iMessage;
        }

        public async Task Add(Message Objeto)
        {
            var validaTitulo = Objeto.ValidaPropriedadeString(Objeto.Titulo, "Titulo");

            if (validaTitulo)
            {
                Objeto.DataCadastro = DateTime.Now;
                Objeto.DataAlteracao = DateTime.Now;
                Objeto.Ativo = true;
                await _IMessage.Add(Objeto);
            }
        }
        public async Task Update(Message Objeto)
        {
            var validaTitulo = Objeto.ValidaPropriedadeString(Objeto.Titulo, "Titulo");

            if (validaTitulo)
            {
                Objeto.DataAlteracao = DateTime.Now;
                await _IMessage.Update(Objeto);
            }
        }

        public async Task<List<Message>> ListMessageActive()
        {
            return await _IMessage.ListMessage(n => n.Ativo);
        }
    }
}
