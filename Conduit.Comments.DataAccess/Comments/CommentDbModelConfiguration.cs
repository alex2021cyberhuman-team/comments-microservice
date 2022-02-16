using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Conduit.Comments.DataAccess.Comments;

public class
    CommentDbModelConfiguration : IEntityTypeConfiguration<CommentDbModel>
{
    public void Configure(
        EntityTypeBuilder<CommentDbModel> builder)
    {
        builder.HasIndex(x => x.Created);
        builder.Property(x => x.Id).HasColumnName("comment_id");
        builder.Property(x => x.Created).HasValueGenerator((
            _,
            _) => DateTimeGenerator.Instance);
        builder.Property(x => x.Updated).HasValueGenerator((
            _,
            _) => DateTimeGenerator.Instance);
    }

    public class DateTimeGenerator : ValueGenerator<DateTime>
    {
        public static DateTimeGenerator Instance { get; } = new();

        public override DateTime Next(
            EntityEntry entry)
        {
            return DateTime.UtcNow;
        }

        public override bool GeneratesTemporaryValues { get; } = false;
    }
}
