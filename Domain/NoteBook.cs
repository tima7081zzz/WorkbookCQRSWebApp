namespace Domain;

public class NoteBook
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastActivityDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Note> Notes { get; set; }
}