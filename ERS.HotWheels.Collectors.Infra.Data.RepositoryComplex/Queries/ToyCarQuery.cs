using ERS.HotWheels.Collectors.App.Core.Dtos.Queries;
using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Infra.Data.Dapper;
using ERS.HotWheels.Collectors.Infra.Data.Queries.Queries.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace ERS.HotWheels.Collectors.Infra.Data.Queries.Queries
{
    public class ToyCarQuery : IToyCarQuery
    {
        private readonly IDapperContext _dapperContext;

        public ToyCarQuery(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> GetCountByCollectionAsync(Guid collectionId, CancellationToken cancellationToken)
        {
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(_dapperContext.ConnectionCreate(), compiler);

            var toyCar = SqlKataHelper.CreateTableDefinition<ToyCar>("tc");
            var collection = SqlKataHelper.CreateTableDefinition<Collection>("c");

            var query = db.Query(toyCar.FullTableName)
                .Join(collection.FullTableName, toyCar.Col(x => x.CollectionId), collection.Col(x => x.Id))
                .SelectRaw("COUNT(*) AS Qtde")
                .Where(toyCar.Col(x => x.CollectionId), collectionId);

            Console.WriteLine(db.Compiler.Compile(query).Sql);

            return await query.FirstOrDefaultAsync<int>();
        }

        public async Task<List<CollectionsDetailsDto>> ListToyCarsAsync(CancellationToken cancellationToken)
        {
            var db = new QueryFactory(_dapperContext.ConnectionCreate(), new SqlServerCompiler());

            var toyCar = SqlKataHelper.CreateTableDefinition<ToyCar, CollectionsDetailsDto>("tc", "dbo");
            var collection = SqlKataHelper.CreateTableDefinition<Collection, CollectionsDetailsDto>("c", "dbo");
            
            var query = db.Query(collection.FullTableName)
                .Join(toyCar.FullTableName, toyCar.Col(x => x.CollectionId), collection.Col(x => x.Id))
                .Select(new[]
                {
                    toyCar.Col(entity => entity.Name, projetion => projetion.ToyCarName),
                    collection.Col(entity => entity.Name, projetion => projetion.CollectionName)
                });

            Console.WriteLine(db.Compiler.Compile(query).Sql);

            return (await query.GetAsync<CollectionsDetailsDto>(cancellationToken: cancellationToken)).ToList();
        }
    }
}
