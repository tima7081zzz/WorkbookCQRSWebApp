using Application.Common.Mappings;
using Domain;

namespace Application.DTOs;

public class NoteLookupDto : IMapWith<Note>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}