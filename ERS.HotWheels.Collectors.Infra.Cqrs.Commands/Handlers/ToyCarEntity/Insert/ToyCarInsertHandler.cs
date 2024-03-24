using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories;
using MediatR;

namespace ERS.HotWheels.Collectors.Infra.Cqrs.Commands.Handlers.ToyCarEntity.Insert
{
    public class ToyCarInsertHandler : IRequestHandler<ToyCarInsertRequest, Guid>
    {
        private readonly IToyCarRepository _toyCarRepository;

        public ToyCarInsertHandler(IToyCarRepository toyCarRepository)
        {
            _toyCarRepository = toyCarRepository;
        }

        public async Task<Guid> Handle(
            ToyCarInsertRequest request, 
            CancellationToken cancellationToken = default)
        {
            var carToy = MapRequestToEntity(request);

            _toyCarRepository.Add(carToy);

            try
            {
                _toyCarRepository.Save();
                return await Task.FromResult(carToy.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static ToyCar MapRequestToEntity(ToyCarInsertRequest request)
            => new ()
            {
                Id = Guid.NewGuid(),
                Name = request.Name ?? string.Empty,
                ReleaseYear = request.ReleaseYear,
                BrandId = request.BrandId,
                CollectionIndex = request.CollectionIndex,
                Tampography = request.Tampography,
                WheelTypeId = request.WheelTypeId,
                CollectionId = request.CollectionId
            };
    }
}
