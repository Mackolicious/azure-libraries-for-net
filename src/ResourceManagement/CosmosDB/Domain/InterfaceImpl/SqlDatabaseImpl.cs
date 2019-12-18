﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    internal partial class SqlDatabaseImpl
    {
        /// <summary>
        /// Gets name of the Cosmos DB SQL database
        /// </summary>
        string ISqlDatabase.SqlDatabaseId
        {
            get
            {
                return this.SqlDatabaseId();
            }
        }

        /// <summary>
        /// Gets a system generated property. A unique identifier.
        /// </summary>
        string ISqlDatabase._rid
        {
            get
            {
                return this._rid();
            }
        }

        /// <summary>
        /// Gets a system generated property that denotes the last
        /// updated timestamp of the resource.
        /// </summary>
        object ISqlDatabase._ts
        {
            get
            {
                return this._ts();
            }
        }

        /// <summary>
        /// Gets a system generated property representing the resource
        /// etag required for optimistic concurrency control.
        /// </summary>
        string ISqlDatabase._etag
        {
            get
            {
                return this._etag();
            }
        }

        /// <summary>
        /// Gets a system generated property that specified the
        /// addressable path of the collections resource.
        /// </summary>
        string ISqlDatabase._colls
        {
            get
            {
                return this._colls();
            }
        }

        /// <summary>
        /// Gets a system generated property that specifies the
        /// addressable path of the users resource.
        /// </summary>
        string ISqlDatabase._users
        {
            get
            {
                return this._users();
            }
        }

        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<ISqlDatabase, ICosmosDBAccount>.Id
        {
            get
            {
                return this.Id();
            }
        }

        SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasOptions.Definition.IWithOptions<SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlDatabase.Update.IUpdate HasOptions.Update.IWithOptions<SqlDatabase.Update.IUpdate>.WithOption(string key, string value)
        {
            return this.WithOption(key, value);
        }

        SqlDatabase.Update.IUpdate HasOptions.Update.IWithOptions<SqlDatabase.Update.IUpdate>.WithOptionsAppend(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsAppend(options);
        }

        SqlDatabase.Update.IUpdate HasOptions.Update.IWithOptions<SqlDatabase.Update.IUpdate>.WithOptionsReplace(System.Collections.Generic.IDictionary<string, string> options)
        {
            return this.WithOptionsReplace(options);
        }

        SqlDatabase.Update.IUpdate HasOptions.Update.IWithOptions<SqlDatabase.Update.IUpdate>.WithoutOption(string key)
        {
            return this.WithoutOption(key);
        }

        SqlDatabase.Update.IUpdate HasOptions.Update.IWithOptions<SqlDatabase.Update.IUpdate>.WithoutOptions()
        {
            return this.WithoutOptions();
        }

        SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate> HasThroughputSettings.Definition.IWithThroughput<SqlDatabase.Definition.IWithAttach<CosmosDBAccount.Definition.IWithCreate>>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        SqlDatabase.Update.IUpdate HasThroughputSettings.Update.IWithThroughput<SqlDatabase.Update.IUpdate>.WithThroughput(int throughput)
        {
            return this.WithThroughput(throughput);
        }

        CosmosDBAccount.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<CosmosDBAccount.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        CosmosDBAccount.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IUpdate>.Parent()
        {
            return this.Attach();
        }
    }
}
