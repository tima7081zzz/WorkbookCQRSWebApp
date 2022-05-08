using Application.Common.Mappings;
using Domain;

namespace Application.DTOs;

public class NoteLookupDto : IMapFrom<Note>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}