using MapsterMapper;
using Mb.Application.Common.Exceptions;
using Mb.Application.Common.Interfaces;
using Mb.Application.Common.Models;
using Mb.Application.Dto;
using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mb.Business.Movies.Commands;

public class DeleteMovieCommand: IRequestWrapper<MovieDto>
{
    public Guid Id { get; set; }
}

public class DeleteMovieCommandHandler : IRequestHandlerWrapper<DeleteMovieCommand, MovieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteMovieCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<MovieDto>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies
            .Where(m => m.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Movie), request.Id);

        _context.Movies.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return ServiceResult.Success<MovieDto>(_mapper.Map<MovieDto>(entity));
    }
}