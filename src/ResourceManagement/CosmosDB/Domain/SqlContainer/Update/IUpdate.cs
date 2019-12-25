﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.SqlContainer.Update
{
    using System.Collections.Generic;

    /// <summary>
    /// The entirety of a SQL container update as a part of parent update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.SqlDatabase.Update.IUpdate>,
        IWithOptions,
        IWithThroughput,
        IWithIndexingPolicy,
        IWithPartitionKey,
        IWithDefaultTtl,
        IWithUniqueKeyPolicy,
        IWithConflictResolutionPolicy,
        IWithChildResource
    {
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set options.
    /// </summary>
    public interface IWithOptions :
        HasOptions.Update.IWithOptions<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set through put.
    /// </summary>
    public interface IWithThroughput :
        HasThroughputSettings.Update.IWithThroughput<IUpdate>
    {
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set indexing policy.
    /// </summary>
    public interface IWithIndexingPolicy
    {
        /// <summary>
        /// Specifies the indexing policy.
        /// </summary>
        /// <param name="indexingPolicy">The indexing policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithIndexingPolicy(Models.IndexingPolicy indexingPolicy);

        /// <summary>
        /// Removes the indexing policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutIndexingPolicy();

        /// <summary>
        /// Starts the update of the indexing policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IndexingPolicy.Update.IUpdate<IUpdate> UpdateIndexingPolicy();
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set partition key.
    /// </summary>
    public interface IWithPartitionKey
    {
        /// <summary>
        /// Specifies the container partition key.
        /// </summary>
        /// <param name="containerPartitionKey">The whole object of the container partition key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithContainerPartitionKey(Models.ContainerPartitionKey containerPartitionKey);

        /// <summary>
        /// Specifies the container partition key.
        /// </summary>
        /// <param name="paths">List of paths using which data within the container can be partitioned.</param>
        /// <param name="kind">Indicates the kind of algorithm used for partitioning. Possible values include: 'Hash', 'Range'.</param>
        /// <param name="version">Indicates the version of the partition key definition.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithContainerPartitionKey(IList<string> paths, Models.PartitionKind kind, int? version);

        /// <summary>
        /// Removes the container partition key.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutContainerPartitionKey();
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set default ttl.
    /// </summary>
    public interface IWithDefaultTtl
    {
        /// <summary>
        /// Specifies the default time to live.
        /// </summary>
        /// <param name="ttl">The default time to live.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithDefaultTtl(int ttl);

        /// <summary>
        /// Removes the default ttl.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutDefaultTtl();
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set unique key policy.
    /// </summary>
    public interface IWithUniqueKeyPolicy
    {
        /// <summary>
        /// Specifies the unique key policy.
        /// </summary>
        /// <param name="uniqueKeyPolicy">The whole object of the unique key policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKeyPolicy(Models.UniqueKeyPolicy uniqueKeyPolicy);

        /// <summary>
        /// Removes the unique key policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutUniqueKeyPolicy();

        /// <summary>
        /// Appends the list of unique key.
        /// </summary>
        /// <param name="uniqueKeys">The list of unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKeys(IList<Models.UniqueKey> uniqueKeys);

        /// <summary>
        /// Specifies a unique key.
        /// </summary>
        /// <param name="uniqueKey">A unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUniqueKey(Models.UniqueKey uniqueKey);

        /// <summary>
        /// Removes a unique key.
        /// </summary>
        /// <param name="uniqueKey">A unique key.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutUniqueKey(Models.UniqueKey uniqueKey);
    }

    /// <summary>
    /// The stage of a SQL container update allowing to set conflict resolution policy.
    /// </summary>
    public interface IWithConflictResolutionPolicy
    {
        /// <summary>
        /// Specifies the conflict resolution policy.
        /// </summary>
        /// <param name="conflictResolutionPolicy">The whole object of the conflict resolution policy.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithConflictResolutionPolicy(Models.ConflictResolutionPolicy conflictResolutionPolicy);

        /// <summary>
        /// Removes the conflict resolution policy.
        /// </summary>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutConflictResolutionPolicy();
    }

    /// <summary>
    /// The stage of a SQL container update allowing to specify child resource.
    /// </summary>
    public interface IWithChildResource
    {
        /// <summary>
        /// Specifies a stored procedure.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <param name="resource">The store procedure resource, no need to specify id.</param>
        /// <param name="options">The options for the store procedure.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithStoredProcedure(string name, Models.SqlStoredProcedureResource resource = default(Models.SqlStoredProcedureResource), IDictionary<string, string> options = default(IDictionary<string, string>));

        /// <summary>
        /// Removes a stored procedure.
        /// </summary>
        /// <param name="name">The name of the stored procedure.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutStoredProcedure(string name);

        /// <summary>
        /// Specifies a user defined function.
        /// </summary>
        /// <param name="name">The name of the user defined function.</param>
        /// <param name="resource">The user defined function resource, no need to specify id.</param>
        /// <param name="options">The options for the user defined function.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithUserDefinedFunction(string name, Models.SqlUserDefinedFunctionResource resource = default(Models.SqlUserDefinedFunctionResource), IDictionary<string, string> options = default(IDictionary<string, string>));

        /// <summary>
        /// Removes a user defined function.
        /// </summary>
        /// <param name="name">The name of the user defined function.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutUserDefinedFunction(string name);

        /// <summary>
        /// Specifies a trigger.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        /// <param name="resource">The trigger resource, no need to specify id.</param>
        /// <param name="options">The options for the trigger.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithTrigger(string name, Models.SqlTriggerResource resource = default(Models.SqlTriggerResource), IDictionary<string, string> options = default(IDictionary<string, string>));

        /// <summary>
        /// Removes a trigger.
        /// </summary>
        /// <param name="name">The name of the trigger.</param>
        /// <returns>The next stage of the update.</returns>
        IUpdate WithoutTrigger(string name);
    }
}