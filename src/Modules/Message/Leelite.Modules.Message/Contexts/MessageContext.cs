using System;
using Leelite.Framework.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.Message.Contexts
{
    public class MessageContext : EFDbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
