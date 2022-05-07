using Application.NoteBooks.Commands;
using Application.NoteBooks.Queries;
using Application.Notes.Commands;
using Application.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class NoteController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<NoteListResponseModel>> GetAll([FromBody] Guid model)
    {
        var query = new GetNoteListQuery
        {
            NoteBookId = model,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteListResponseModel>> Get(Guid id, [FromBody] Guid noteBookId)
    {
        var query = new GetNoteDetailsQuery
        {
            NoteBookId = noteBookId,
            Id = id,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteCommand query)
    {
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
    public async Task<ActionResult> Delete(Guid id)
    {
        var query = new DeleteNoteCommand
        {
            Id = id,
        };
        await Mediator.Send(query);
        return Ok();
    }
}