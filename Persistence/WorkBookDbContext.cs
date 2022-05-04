using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Persistence.EntitiesConfiguration;

namespace Persistence;

public class WorkBookDbContext : DbContext, IWorkBookDbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteBook> NoteBooks { get; set; }

    public WorkBookDbContext(DbContextOptions<WorkBookDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}