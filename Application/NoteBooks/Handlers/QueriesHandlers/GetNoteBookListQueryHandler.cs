using Application.Common.Exceptions;
using Application.DTOs;
using Application.Interfaces;
using Application.NoteBooks.Queries;
using Application.NoteBooks.ResponseModels;
using Application.ResponseModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Handlers.QueriesHandlers;

public class GetNoteBookListQueryHandler : IRequestHandler<GetNoteBookListQuery, NoteBookListResponseModel>
{
    private readonly IWorkBookDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNoteBookListQueryHandler(IWorkBookDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NoteBookListResponseModel> Handle(GetNoteBookListQuery request, CancellationToken ct)
    {
        var noteBooks = await _dbContext.NoteBooks.Where(x => x.UserId == request.UserId)
            .ProjectTo<NoteBookLookupDto>(_mapper.ConfigurationProvider).ToListAsync(ct);

        if (!noteBooks.Any())
        {
            throw new NotFoundException(nameof(NoteBook), request.UserId);
        }

        return new NoteBookListResponseModel
        {
            NoteBooks = noteBooks
        };
    }
}