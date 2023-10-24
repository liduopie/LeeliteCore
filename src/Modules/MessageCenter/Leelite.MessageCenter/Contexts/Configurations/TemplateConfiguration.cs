using Leelite.MessageCenter.Models.TemplateAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.MessageCenter.Contexts.Configurations
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.Template);

            builder.Property(u => u.PlatformId);
            builder.Property(u => u.MessageTypeCode).HasMaxLength(256);
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.Description).HasMaxLength(512);

            builder.Property(u => u.TemplateCode).HasMaxLength(256);
            builder.Property(u => u.ContentTemplate).HasMaxLength(512);
            builder.Property(u => u.UrlTemplate).HasMaxLength(512);
        }
    }
}
