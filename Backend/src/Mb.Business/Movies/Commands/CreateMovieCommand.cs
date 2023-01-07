using FluentValidation;
using MapsterMapper;
using Mb.Application.Common.Interfaces;
using Mb.Application.Common.Models;
using Mb.Application.Dto;
using Mb.Domain.Entities;
using Mb.Domain.Event;

namespace Mb.Business.Movies.Commands;

public record CreateMovieCommand(string Title, string Description, int Year, decimal Rating, Guid ImageId, 
    Guid CategoryId) : IRequestWrapper<MovieDto>;

public class CreateMovieCommandHandler : IRequestHandlerWrapper<CreateMovieCommand, MovieDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateMovieCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<MovieDto>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = new Movie
        {
            Title = request.Title,
            Description = request.Description,
            Year = request.Year,
            Rating = request.Rating,
            CategoryId = request.CategoryId,
            ImageId = request.ImageId
        };
        
        entity.DomainEvents.Add(new MovieCreatedEvent(entity));
        await _context.Movies.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<MovieDto>(entity));
    }
}

public class CreateMovieCommandValidator: AbstractValidator<CreateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMovieCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.Title)
            .MaximumLength(250).WithMessage("Title must not exceed 100 characters.")
            .NotEmpty().WithMessage("Please insert movie title.");
    }
}