using System;
using Leelite.Framework.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.MessageCenter.Contexts
{
    public class MessageCenterContext : EFDbContext
    {
        public MessageCenterContext(DbContextOptions<MessageCenterContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
