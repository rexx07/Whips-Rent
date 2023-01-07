using FluentValidation;
using MapsterMapper;
using Mb.Application.Common.Exceptions;
using Mb.Application.Common.Interfaces;
using Mb.Application.Common.Models;
using Mb.Application.Dto;
using Mb.Domain.Entities;
using MediatR;

namespace Mb.Business.Movies.Commands;

public class UpdateMovieCommand: IRequestWrapper<MovieDto>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public decimal Rating { get; set; }
    public Guid ImageId { get; set; }
    public ImageDto Image { get; set; }
    public Guid? CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}

public class UpdateMovieCommandHandler : IRequestHandlerWrapper<UpdateMovieCommand, MovieDto>
{
    public readonly IApplicationDbContext _context;
    public readonly IMapper _mapper;

    public UpdateMovieCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<MovieDto>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(request.Id);

        if (entity == null)
            throw new NotFoundException(nameof(Movie), request.Id);
        var movie = new Movie
        {
            Title = request.Title,
            Description = request.Description,
            Year = request.Year,
            Rating = request.Rating,
            CategoryId = request.CategoryId,
            ImageId = request.ImageId
        };
        
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(_mapper.Map<MovieDto>(entity));
    }
}

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateMovieCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(m => m.Title)
            .MaximumLength(250)
            .NotEmpty().WithMessage("Please insert movie title.");
        
        
    }
}