using Application.DTOs;

namespace Application.ResponseModels
{
    public class NoteListResponseModel
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}