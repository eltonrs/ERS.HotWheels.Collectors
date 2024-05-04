using ERS.HotWheels.Collectors.App.Core.Dtos.Queries;

namespace ERS.HotWheels.Collectors.Infra.Data.Queries.Queries.Interfaces
{
    public interface IToyCarQuery
    {
        Task<int> GetCountByCollectionAsync(Guid collectionId, CancellationToken cancellationToken);
        Task<List<CollectionsDetailsDto>> ListToyCarsAsync(CancellationToken cancellationToken);
    }
}
