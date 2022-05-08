using Application.Common.Mappings;
using Domain;

namespace Application.Notes.Queries.GetNoteDetails;

public class NoteDetailsResponseModel : IMapFrom<Note>
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastActivityDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}