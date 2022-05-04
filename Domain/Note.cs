namespace Domain;

public class Note
{
    public Guid Id { get; set; }
    public Guid NoteBookId { get; set; }
    public virtual NoteBook NoteBook { get; set; }
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}