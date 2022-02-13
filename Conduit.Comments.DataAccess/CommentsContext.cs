using System.Reflection;
using Conduit.Comments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Comments.DataAccess;

public class CommentsContext : DbContext
{
    protected CommentsContext()
    {
    }

    public CommentsContext(
        DbContextOptions<CommentsContext> options) : base(options)
    {
    }

    public DbSet<ArticleDbModel> Article => Set<ArticleDbModel>();

    public DbSet<AuthorDbModel> Author => Set<AuthorDbModel>();
    
    public DbSet<CommentsDbModel> Comments => Set<CommentsDbModel>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
