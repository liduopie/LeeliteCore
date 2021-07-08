using System;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.MessageCenter.Contexts.Configurations
{
    public class PushPlatformConfiguration : IEntityTypeConfiguration<PushPlatform>
    {
        public void Configure(EntityTypeBuilder<PushPlatform> builder)
        {
            throw new NotImplementedException();
        }
    }
}
