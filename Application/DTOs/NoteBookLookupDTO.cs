using Application.Common.Mappings;
using Domain;

namespace Application.DTOs;

public class NoteBookLookupDto : IMapFrom<NoteBook>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }

}