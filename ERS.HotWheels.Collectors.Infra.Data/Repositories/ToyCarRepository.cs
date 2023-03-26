using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories;
using ERS.HotWheels.Collectors.Infra.Context;
using ERS.HotWheels.Collectors.Infra.Data.Repository.Repositories.Base;

namespace ERS.HotWheels.Collectors.Infra.Data.Repository.Repositories
{
    public class ToyCarRepository : RepositoryBase<ToyCar>, IToyCarRepository
    {
        public ToyCarRepository(HotWheelsCollectorsContext context) : base(context)
        { }
    }
}
