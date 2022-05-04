using Application.Common.Exceptions;
using Application.Interfaces;
using Application.NoteBooks.Queries;
using Application.NoteBooks.ResponseModels;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Handlers.QueriesHandlers;

public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsResponseModel>
{
    private readonly IWorkBookDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteDetailsQueryHandler(IWorkBookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteDetailsResponseModel> Handle(GetNoteDetailsQuery request, CancellationToken ct)
    {
        var noteBook = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (noteBook == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }

        return _mapper.Map<NoteDetailsResponseModel>(noteBook);
    }
}