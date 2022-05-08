using Application.NoteBooks.Queries;
using Application.Notes.Commands;
using Application.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.RequestModels;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class NoteController : BaseController
{
    [HttpGet]
    [Route("{noteBookId:guid}/GetAll")]
    public async Task<ActionResult<NoteListResponseModel>> GetAll(Guid noteBookId)
    {
        var query = new GetNoteListQuery
        {
            NoteBookId = noteBookId,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    [Route("{noteId:guid}/Get")]
    public async Task<ActionResult<NoteListResponseModel>> Get(Guid noteId, [FromBody] Guid noteBookId)
    {
        var query = new GetNoteDetailsQuery
        {
            NoteBookId = noteBookId,
            Id = noteId,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    [Route("{noteBookId:guid}/Create")]
    public async Task<ActionResult<Guid>> Create(Guid noteBookId, [FromBody] CreateNoteRequestModel model)
    {
        var query = new CreateNoteCommand
        {
            Title = model.Title,
            Text = model.Text,
            NoteBookId = noteBookId,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateNoteCommand query)
    {
        await Mediator.Send(query);
        return Ok();
    }

    [HttpDelete]
    [Route("{noteId:guid}/Create")]
    public async Task<ActionResult> Delete(Guid noteId)
    {
        var query = new DeleteNoteCommand
        {
            Id = noteId,
        };
        await Mediator.Send(query);
        return Ok();
    }
}