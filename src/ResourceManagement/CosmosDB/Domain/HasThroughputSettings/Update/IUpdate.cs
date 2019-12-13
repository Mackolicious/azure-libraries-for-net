﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.CosmosDB.Fluent.HasThroughputSettings.Update
{
    /// <summary>
    /// The stage of a resource update allowing to set throughput.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the update.</typeparam>
    public interface IWithThroughput<ReturnT>
    {
        /// <summary>
        /// Specifies throughput.
        /// </summary>
        /// <param name="throughput">The vaule of throughput.</param>
        /// <returns>The next stage of the update.</returns>
        ReturnT WithThroughput(int throughput);
    }
}
