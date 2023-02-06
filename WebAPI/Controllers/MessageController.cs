using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper iMapper;
        private readonly IMessage iMessage;
        private readonly IServiceMessage iServiceMessage;

        public MessageController(IMapper iMapper, IMessage iMessage, IServiceMessage iServiceMessage)
        {
            this.iMapper = iMapper;
            this.iMessage = iMessage;
            this.iServiceMessage = iServiceMessage;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.UserId = await RetornarIdUsuarioLogado();
            var messageMap = iMapper.Map<Message>(message);
            await iServiceMessage.Add(messageMap);
            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {
            var messageMap = iMapper.Map<Message>(message);
            await iServiceMessage.Update(messageMap);
            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
            var messageMap = iMapper.Map<Message>(message);
            await iMessage.Delete(messageMap);
            return messageMap.Notificacoes;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {
            message = await iMessage.GetEntityById(message.Id);
            var messageMap = iMapper.Map<MessageViewModel>(message);
            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var mensagens = await iMessage.List();
            var messageMap = iMapper.Map<List<MessageViewModel>>(mensagens);
            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListMessageActive")]
        public async Task<List<MessageViewModel>> ListMessageActive()
        {
            var mensagens = await iServiceMessage.ListMessageActive();
            var messageMap = iMapper.Map<List<MessageViewModel>>(mensagens);
            return messageMap;
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }
            return string.Empty;
        }
    }
}
