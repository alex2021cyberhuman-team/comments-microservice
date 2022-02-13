using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Conduit.Comments.DataAccess.Models;

public class
    CommentsDbModelConfiguration : IEntityTypeConfiguration<CommentsDbModel>
{
    public void Configure(
        EntityTypeBuilder<CommentsDbModel> builder)
    {
        builder.HasIndex(x => x.Created);
        builder.Property(x => x.Created).HasValueGenerator((_, _) => DateTimeGenerator.Instance);
        builder.Property(x => x.Updated).HasValueGenerator((_, _) => 
            DateTimeGenerator.Instance);
    }

    public class DateTimeGenerator : ValueGenerator<DateTime>
    {
        private static readonly DateTimeGenerator _dateTimeGenerator = new();

        public static DateTimeGenerator Instance => _dateTimeGenerator;

        public override DateTime Next(
            EntityEntry entry)
        {
            return DateTime.UtcNow;
        }

        public override bool GeneratesTemporaryValues { get; } = false;
    }
}