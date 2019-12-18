// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a sql database collection.
    /// </summary>
    internal partial class SqlDatabasesImpl :
        ExternalChildResourcesCached<
            SqlDatabaseImpl,
            ISqlDatabase,
            SqlDatabaseGetResultsInner,
            ICosmosDBAccount,
            CosmosDBAccountImpl>
    {
        private ISqlResourcesOperations Client { get; set; }
        internal SqlDatabasesImpl(ISqlResourcesOperations client, CosmosDBAccountImpl parent)
            : base(parent, "SqlDatabase")
        {
            this.Client = client;
            this.CacheCollection();
        }

        protected override IList<SqlDatabaseImpl> ListChildResources()
        {
            return Extensions.Synchronize(() => ListAsync()).ToList();
        }

        protected override SqlDatabaseImpl NewChildResource(string name)
        {
            return new SqlDatabaseImpl(name, Parent, new SqlDatabaseGetResultsInner(null, name: name), Client);

        }

        public async Task<SqlDatabaseImpl> GetImplAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Client.GetSqlDatabaseAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                name,
                cancellationToken
                );
            return new SqlDatabaseImpl(name, Parent, inner, Client);
        }

        public SqlDatabaseImpl Define(string name)
        {
            return this.PrepareDefine(name);
        }

        public async Task<IEnumerable<SqlDatabaseImpl>> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await ListInnerAsync(cancellationToken);
            return result.Select(inner => new SqlDatabaseImpl(inner.Name, Parent, inner, Client));
        }

        private async Task<IEnumerable<SqlDatabaseGetResultsInner>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Client.ListSqlDatabasesAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                cancellationToken
                );
        }

        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }

        public SqlDatabaseImpl Update(string name)
        {
            return this.PrepareUpdate(name);
        }

        public void AddSqlDatabase(SqlDatabaseImpl sqlDatabase)
        {
            this.AddChildResource(sqlDatabase);
        }
    }
}