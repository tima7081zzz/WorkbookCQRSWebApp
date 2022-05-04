using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;

public class NoteBookConfiguration : IEntityTypeConfiguration<NoteBook>
{
    public void Configure(EntityTypeBuilder<NoteBook> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Title).HasMaxLength(250);
    }
}