namespace Application.Notes.Queries.GetNoteList
{
    public class NoteListResponseModel
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}