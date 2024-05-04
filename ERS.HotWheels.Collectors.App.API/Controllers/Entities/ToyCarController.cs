using ERS.HotWheels.Collectors.App.Core.Dtos.Queries;
using ERS.HotWheels.Collectors.App.Core.Dtos.ToyCarEntity;
using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories;
using ERS.HotWheels.Collectors.Infra.Cqrs.Commands.Handlers.ToyCarEntity.Insert;
using ERS.HotWheels.Collectors.Infra.Data.Queries.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERS.HotWheels.Collectors.App.API.Controllers.Entities
{
    [ApiController]
    [Route("[controller]")]
    public class ToyCarController : Controller
    {
        private readonly ILogger<ToyCarController> _logger;
        private readonly IToyCarRepository _toyCarRepository;
        private readonly IMediator _mediator;

        public ToyCarController(
            ILogger<ToyCarController> logger,
            IToyCarRepository toyCarRepository,
            IMediator mediator
        )
        {
            _logger = logger;
            _toyCarRepository = toyCarRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToyCar>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var toyCars = await _toyCarRepository.GetAllAsync(cancellationToken);

            return Ok(toyCars.Any() ? toyCars.ToArray() : Array.Empty<ToyCar>());
        }

        [HttpGet("by-collection")]
        public async Task<ActionResult<IEnumerable<CollectionsDetailsDto>>> GetByCollectionAsync(
            CancellationToken cancellationToken,
            [FromServices] IToyCarQuery toyCarRepositoryComplex)
        {
            var toyCarsDetails = await toyCarRepositoryComplex.ListToyCarsAsync(cancellationToken);

            return Ok(toyCarsDetails.Count != 0 ? [.. toyCarsDetails] : Array.Empty<CollectionsDetailsDto>());
        }

        [HttpGet("{collectionId:guid}/Count")]
        public async Task<ActionResult<IEnumerable<ToyCar>>> GetCountByCollectionAsync(
            Guid collectionId,
            CancellationToken cancellationToken,
            [FromServices] IToyCarQuery toyCarRepositoryComplex)
        {
            var count = await toyCarRepositoryComplex.GetCountByCollectionAsync(
                collectionId,
                cancellationToken);

            return Ok(count);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ToyCarDetailsDto>> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var toyCar = await _toyCarRepository.GetByIdAsync(id, cancellationToken);

            if (toyCar is null)
                return NotFound();

            return new ToyCarDetailsDto
            {
                Name = toyCar.Name,
                ReleaseYear = toyCar.ReleaseYear,
                BrandId = toyCar.BrandId,
                CollectionIndex = toyCar.CollectionIndex,
                Tampography = toyCar.Tampography
            };
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Save(ToyCarInsertRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
