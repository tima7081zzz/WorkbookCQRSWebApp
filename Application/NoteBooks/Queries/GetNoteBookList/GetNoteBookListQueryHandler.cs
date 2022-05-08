using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Queries.GetNoteBookList;

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