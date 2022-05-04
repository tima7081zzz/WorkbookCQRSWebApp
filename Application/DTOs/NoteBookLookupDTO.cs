using Application.Common.Mappings;
using Domain;

namespace Application.DTOs;

public class NoteBookLookupDto : IMapWith<NoteBook>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}