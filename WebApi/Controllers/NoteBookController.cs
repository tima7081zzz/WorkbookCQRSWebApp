using Application.NoteBooks.Commands;
using Application.NoteBooks.Commands.CreateNoteBook;
using Application.NoteBooks.Commands.DeleteNoteBook;
using Application.NoteBooks.Commands.UpdateNoteBook;
using Application.NoteBooks.Queries;
using Application.NoteBooks.Queries.GetNoteBookDetails;
using Application.NoteBooks.Queries.GetNoteBookList;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.RequestModels;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class NoteBookController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<NoteBookListResponseModel>> GetAll()
    {
        var query = new GetNoteBookListQuery
        {
            UserId = UserId
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<NoteBookDetailsResponseModel>> Get(Guid id)
    {
        var query = new GetNoteBookDetailsQuery
        {
            UserId = UserId,
            Id = id,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteBookRequestModel model)
    {
        var query = new CreateNoteBookCommand
        {
            UserId = UserId,
            Title = model.Title,
            Description = model.Description,
        };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] CreateNoteBookRequestModel model)
    {
        var query = new UpdateNoteBookCommand
        {
            UserId = UserId,
            Id = default,
            Title = model.Title,
            Description = model.Description,
        };
        await Mediator.Send(query);

        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        var query = new DeleteNoteBookCommand
        {
            UserId = UserId,
            Id = id
        };
        await Mediator.Send(query);

        return Ok();
    }
}