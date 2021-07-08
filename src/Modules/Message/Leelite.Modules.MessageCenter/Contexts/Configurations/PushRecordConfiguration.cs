using System;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.MessageCenter.Contexts.Configurations
{
    public class PushRecordConfiguration : IEntityTypeConfiguration<PushRecord>
    {
        public void Configure(EntityTypeBuilder<PushRecord> builder)
        {
            throw new NotImplementedException();
        }
    }
}
