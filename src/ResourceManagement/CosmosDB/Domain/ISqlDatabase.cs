﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    public interface ISqlDatabase :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.SqlDatabaseGetResultsInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlDatabase, ICosmosDBAccount>
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database
        /// </summary>
        string SqlDatabaseId { get; }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string _rid { get; }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object _ts { get; }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string _etag { get; }

        /// <summary>
        /// Gets a system generated property that specified the
        /// addressable path of the collections resource.
        /// </summary>
        string _colls { get; }

        /// <summary>
        /// Gets a system generated property that specifies the
        /// addressable path of the users resource.
        /// </summary>
        string _users { get; }

        /// <returns>The throughput settings of sql database.</returns>
        ThroughputSettingsGetPropertiesResource GetThroughputSettings();

        /// <returns>The throughput settings of sql database.</returns>
        Task<ThroughputSettingsGetPropertiesResource> GetThroughputSettingsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
