using System.Linq.Expressions;
using System.Reflection;

namespace ERS.HotWheels.Collectors.Infra.Data.Queries
{
    internal class SqlKataHelper
    {
        public static TableDefinition<TTable, TProjection> CreateTableDefinition<TTable, TProjection>(
            string tableAlias,
            string tableSchema = "")
            where TTable : class
            where TProjection : class
        {
            var sqlAlias = new TableDefinition<TTable, TProjection>()
            {
                TableName = typeof(TTable).Name,
                TableAlias = tableAlias,
                TableSchema = tableSchema
            };

            return sqlAlias;
        }

        public static TableDefinition<TTable, TTable> CreateTableDefinition<TTable>(
            string tableAlias,
            string tableSchema = "")
            where TTable : class
        {
            var sqlAlias = new TableDefinition<TTable, TTable>()
            {
                TableName = typeof(TTable).Name,
                TableAlias = tableAlias,
                TableSchema = tableSchema
            };

            return sqlAlias;
        }
    }

    internal class TableDefinition<TTable, TProjection>
        where TTable : class
        where TProjection : class
    {
        private const string AsSeparator = " AS ";
        private const string AliasSeparator = ".";

        public string TableSchema { get; set; } = "";
        public string TableName { get; set; } = "";
        public string TableAlias { get; set; } = "";

        public string FullTableName {
            get
            {
                var fullTableName = TableName;

                if (!string.IsNullOrWhiteSpace(TableSchema))
                    fullTableName = string.Concat(TableSchema, AliasSeparator, fullTableName);

                return string.IsNullOrWhiteSpace(TableAlias)
                    ? fullTableName
                    : string.Concat(fullTableName, AsSeparator, TableAlias);
            }
        }

        public string Col(
            Expression<Func<TTable, object>> columnProperty,
            Expression<Func<TProjection, object>>? projectionProperty = null)
        {
            var columnAlias = string.Empty;
            
            var columnMember = GetMember(columnProperty);

            var columnName = string.IsNullOrWhiteSpace(TableAlias)
                ? columnMember.Name
                : string.Concat(TableAlias, AliasSeparator, columnMember.Name);

            if (projectionProperty != null)
            {
                var projetctionMember = GetMember(projectionProperty);
                columnAlias = projetctionMember.Name;
            }
            
            return string.IsNullOrWhiteSpace(columnAlias)
                ? columnName
                : string.Concat(columnName, AsSeparator, columnAlias);
        }

        private static PropertyInfo GetMember<T>(Expression<Func<T, object>> property)
            where T : class
        {
            LambdaExpression lambda = property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(lambda.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return (PropertyInfo)memberExpression.Member;
        }
    }
}
