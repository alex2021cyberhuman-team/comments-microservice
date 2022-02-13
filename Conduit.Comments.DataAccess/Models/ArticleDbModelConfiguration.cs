using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conduit.Comments.DataAccess.Models;

public class
    ArticleDbModelConfiguration : IEntityTypeConfiguration<ArticleDbModel>
{
    public void Configure(
        EntityTypeBuilder<ArticleDbModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Slug).IsUnique();
        builder.HasOne(x => x.Author).WithMany(x => x.Articles)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.Id).HasColumnName("article_id");
    }
}
