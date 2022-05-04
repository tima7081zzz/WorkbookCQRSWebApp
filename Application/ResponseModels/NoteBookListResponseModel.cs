using Application.DTOs;

namespace Application.ResponseModels;

public class NoteBookListResponseModel
{
    public IList<NoteBookLookupDto> NoteBooks { get; set; }
}