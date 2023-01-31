using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> optionsBuilder;

        public RepositoryMessage()
        {
            optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Message>> ListMessage(Expression<Func<Message, bool>> exMessage)
        {
            using (var banco = new ContextBase(optionsBuilder))
            {
                return await banco.Message.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
