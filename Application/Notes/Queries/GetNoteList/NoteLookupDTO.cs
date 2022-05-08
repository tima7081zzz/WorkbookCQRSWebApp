using Application.Common.Mappings;
using Domain;

namespace Application.Notes.Queries.GetNoteList;

public class NoteLookupDto : IMapFrom<Note>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}