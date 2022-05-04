using Application.Common.Exceptions;
using Application.DTOs;
using Application.Interfaces;
using Application.NoteBooks.Queries;
using Application.ResponseModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Handlers.QueriesHandlers;

public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListResponseModel>
{
    private readonly IWorkBookDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteListQueryHandler(IWorkBookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteListResponseModel> Handle(GetNoteListQuery request, CancellationToken ct)
    {
        var noteBooks = await _dbContext.Notes.Where(x => x.NoteBookId == request.NoteBookId)
            .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider).ToListAsync(ct);

        if (!noteBooks.Any())
        {
            throw new NotFoundException(nameof(NoteBook), request.NoteBookId);
        }

        return new NoteListResponseModel
        {
            Notes = noteBooks
        };
    }
}