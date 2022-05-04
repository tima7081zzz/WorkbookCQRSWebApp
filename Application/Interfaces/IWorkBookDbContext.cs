using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IWorkBookDbContext
{
    DbSet<Note> Notes { get; set; }
    DbSet<NoteBook> NoteBooks { get; set; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}