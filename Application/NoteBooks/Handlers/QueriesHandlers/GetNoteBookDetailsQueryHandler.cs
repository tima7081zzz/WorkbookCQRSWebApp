using Application.Common.Exceptions;
using Application.Interfaces;
using Application.NoteBooks.Queries;
using Application.NoteBooks.ResponseModels;
using Application.ResponseModels;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Handlers.QueriesHandlers;

public class GetNoteBookDetailsQueryHandler : IRequestHandler<GetNoteBookDetailsQuery, NoteBookDetailsResponseModel>
{
    private readonly IWorkBookDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteBookDetailsQueryHandler(IWorkBookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteBookDetailsResponseModel> Handle(GetNoteBookDetailsQuery request, CancellationToken ct)
    {
        var noteBook = await _dbContext.NoteBooks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, ct);

        if (noteBook == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }

        return _mapper.Map<NoteBookDetailsResponseModel>(noteBook);
    }
}