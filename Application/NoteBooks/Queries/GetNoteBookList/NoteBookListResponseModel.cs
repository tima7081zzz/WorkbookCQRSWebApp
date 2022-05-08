namespace Application.NoteBooks.Queries.GetNoteBookList;

public class NoteBookListResponseModel
{
    public IList<NoteBookLookupDto> NoteBooks { get; set; }
}