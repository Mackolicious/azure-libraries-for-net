// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update;
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.Resource.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DatabaseAccount.
    /// </summary>
    public partial class CosmosDBAccountImpl :
        GroupableResource<
            ICosmosDBAccount,
            Models.DatabaseAccountGetResultsInner,
            CosmosDBAccountImpl,
            ICosmosDBManager,
            IWithGroup,
            IWithKind,
            IWithCreate,
            IUpdate>,
        ICosmosDBAccount,
        IDefinition,
        IUpdate
    {
        private IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.FailoverPolicy> failoverPolicies;
        private bool hasFailoverPolicyChanges;
        private const int maxDelayDueToMissingFailovers = 5000 * 12 * 10;
        private Dictionary<string, List<Models.VirtualNetworkRule>> virtualNetworkRulesMap;
        private PrivateEndpointConnectionsImpl privateEndpointConnections;

        internal CosmosDBAccountImpl(string name, Models.DatabaseAccountGetResultsInner innerObject, ICosmosDBManager manager) :
            base(name, innerObject, manager)
        {
            this.failoverPolicies = new List<Models.FailoverPolicy>();
            this.privateEndpointConnections = new PrivateEndpointConnectionsImpl(this.Manager.Inner.PrivateEndpointConnections, this);
        }

        public CosmosDBAccountImpl WithReadReplication(Region region)
        {
            this.EnsureFailoverIsInitialized();
            Models.FailoverPolicy FailoverPolicy = new Models.FailoverPolicy();
            FailoverPolicy.LocationName = region.Name;
            FailoverPolicy.FailoverPriority = this.failoverPolicies.Count;
            this.hasFailoverPolicyChanges = true;
            this.failoverPolicies.Add(FailoverPolicy);
            return this;
        }

        private async Task<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> DoDatabaseUpdateCreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            CosmosDBAccountImpl self = this;
            int currentDelayDueToMissingFailovers = 0;
            HasLocation locationParameters;

            if (IsInCreateMode)
            {
                Models.DatabaseAccountCreateUpdateParameters createUpdateParametersInner =
                    this.CreateUpdateParametersInner(this.Inner);
                await this.Manager.Inner.DatabaseAccounts.CreateOrUpdateAsync(
                    ResourceGroupName, Name, createUpdateParametersInner);
                locationParameters = new CreateUpdateLocationParameters(createUpdateParametersInner);
            }
            else
            {
                Models.DatabaseAccountUpdateParameters updateParametersInner =
                    this.UpdateParametersInner(this.Inner);
                await this.Manager.Inner.DatabaseAccounts.UpdateAsync(
                    ResourceGroupName, Name, updateParametersInner);
                locationParameters = new UpdateLocationParameters(updateParametersInner);
            }
            this.failoverPolicies.Clear();
            this.hasFailoverPolicyChanges = false;
            bool done = false;
            ICosmosDBAccount databaseAccount = null;
            while (!done)
            {
                await SdkContext.DelayProvider.DelayAsync(5000, cancellationToken);
                databaseAccount = await this.Manager.CosmosDBAccounts.GetByResourceGroupAsync(
                    ResourceGroupName, Name);

                if (maxDelayDueToMissingFailovers > currentDelayDueToMissingFailovers &&
                    (databaseAccount.Id == null
                    || databaseAccount.Id.Length == 0
                    || locationParameters.Locations.Count >
                        databaseAccount.Inner.FailoverPolicies.Count))
                {
                    currentDelayDueToMissingFailovers += 5000;
                    continue;
                }

                if (this.IsProvisioningStateFinal(databaseAccount.Inner.ProvisioningState))
                {
                    done = true;
                    foreach (Models.Location location in databaseAccount.ReadableReplications)
                    {
                        if (!this.IsProvisioningStateFinal(location.ProvisioningState))
                        {
                            done = false;
                            break;
                        }
                    }
                }
            }

            await this.privateEndpointConnections.CommitAndGetAllAsync(cancellationToken);
            this.SetInner(databaseAccount.Inner);
            this.initializeFailover();
            return databaseAccount;
        }

        private Models.DatabaseAccountCreateUpdateParameters CreateUpdateParametersInner(Models.DatabaseAccountGetResultsInner inner)
        {
            this.EnsureFailoverIsInitialized();
            Models.DatabaseAccountCreateUpdateParameters createUpdateParametersInner =
            new Models.DatabaseAccountCreateUpdateParameters();
            createUpdateParametersInner.Location = this.RegionName.ToLower();
            createUpdateParametersInner.ConsistencyPolicy = inner.ConsistencyPolicy;
            createUpdateParametersInner.IpRangeFilter = inner.IpRangeFilter;
            createUpdateParametersInner.Kind = inner.Kind;
            createUpdateParametersInner.Capabilities = inner.Capabilities;
            createUpdateParametersInner.Tags = inner.Tags;
            createUpdateParametersInner.IsVirtualNetworkFilterEnabled = inner.IsVirtualNetworkFilterEnabled;
            createUpdateParametersInner.EnableMultipleWriteLocations = inner.EnableMultipleWriteLocations;
            createUpdateParametersInner.EnableCassandraConnector = inner.EnableCassandraConnector;
            createUpdateParametersInner.ConnectorOffer = inner.ConnectorOffer;
            createUpdateParametersInner.EnableAutomaticFailover = inner.EnableAutomaticFailover;
            createUpdateParametersInner.DisableKeyBasedMetadataWriteAccess = inner.DisableKeyBasedMetadataWriteAccess;
            if (virtualNetworkRulesMap != null)
            {
                createUpdateParametersInner.VirtualNetworkRules = virtualNetworkRulesMap.Values.SelectMany(l => l).ToList();
                virtualNetworkRulesMap = null;
            }
            this.AddLocationsForParameters(new CreateUpdateLocationParameters(createUpdateParametersInner), this.failoverPolicies);
            return createUpdateParametersInner;
        }

        private DatabaseAccountUpdateParameters UpdateParametersInner(DatabaseAccountGetResultsInner inner)
        {
            this.EnsureFailoverIsInitialized();
            var updateParametersInner = new DatabaseAccountUpdateParameters();
            updateParametersInner.Tags = inner.Tags;
            updateParametersInner.Location = this.RegionName.ToLower();
            updateParametersInner.ConsistencyPolicy = inner.ConsistencyPolicy;
            updateParametersInner.IpRangeFilter = inner.IpRangeFilter;
            updateParametersInner.IsVirtualNetworkFilterEnabled = inner.IsVirtualNetworkFilterEnabled;
            updateParametersInner.EnableAutomaticFailover = inner.EnableAutomaticFailover;
            updateParametersInner.Capabilities = inner.Capabilities;
            updateParametersInner.EnableMultipleWriteLocations = inner.EnableMultipleWriteLocations;
            updateParametersInner.EnableCassandraConnector = inner.EnableCassandraConnector;
            updateParametersInner.ConnectorOffer = inner.ConnectorOffer;
            updateParametersInner.DisableKeyBasedMetadataWriteAccess = inner.DisableKeyBasedMetadataWriteAccess;
            if (virtualNetworkRulesMap != null)
            {
                updateParametersInner.VirtualNetworkRules = this.virtualNetworkRulesMap.Values.SelectMany(l => l).ToList();
                this.virtualNetworkRulesMap = null;
            }
            AddLocationsForParameters(new UpdateLocationParameters(updateParametersInner), this.failoverPolicies);
            return updateParametersInner;
        }

        private bool IsProvisioningStateFinal(string state)
        {
            switch (state.ToLower())
            {
                case "succeeded":
                case "canceled":
                case "failed":
                    return true;
                default:
                    return false;
            }
        }

        public IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> WritableReplications()
        {
            return this.Inner.WriteLocations as IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListKeysResult> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts.ListKeysAsync(this.ResourceGroupName,
                this.Name);
            return result != null ? new DatabaseAccountListKeysResultImpl(result) : null;
        }

        public override async Task<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DoDatabaseUpdateCreateAsync(cancellationToken);
        }

        public IDatabaseAccountListKeysResult ListKeys()
        {
            return Extensions.Synchronize(() => this.ListKeysAsync());
        }

        public string IPRangeFilter()
        {
            return this.Inner.IpRangeFilter;
        }

        public string Kind()
        {
            return this.Inner.Kind.Value;
        }
        public bool? MultipleWriteLocationsEnabled()
        {
            return this.Inner.EnableMultipleWriteLocations;
        }

        private void EnsureFailoverIsInitialized()
        {
            if (this.IsInCreateMode)
            {
                return;
            }

            if (!this.hasFailoverPolicyChanges)
            {
                this.initializeFailover();
            }
        }

        private void initializeFailover()
        {
            this.failoverPolicies.Clear();
            Models.FailoverPolicy[] policyInners = new Models.FailoverPolicy[this.Inner.FailoverPolicies.Count];
            for (var i = 0; i < policyInners.Length; i++)
            {
                policyInners[i] = this.Inner.FailoverPolicies[i];
            }

            Array.Sort(policyInners, (o1, o2) =>
            {
                return o1.FailoverPriority.GetValueOrDefault().CompareTo(o2.FailoverPriority.GetValueOrDefault());
            });

            for (int i = 0; i < policyInners.Length; i++)
            {
                this.failoverPolicies.Add(policyInners[i]);
            }

            this.hasFailoverPolicyChanges = true;
        }

        public CosmosDBAccountImpl WithStrongConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Strong, 0, 0);
            return this;
        }

        private void SetConsistencyPolicy(Models.DefaultConsistencyLevel level, long maxStalenessPrefix, int maxIntervalInSeconds)
        {
            var policy = new Models.ConsistencyPolicy();
            policy.DefaultConsistencyLevel = level;
            if (level == Models.DefaultConsistencyLevel.BoundedStaleness)
            {
                policy.MaxIntervalInSeconds = maxIntervalInSeconds;
                policy.MaxStalenessPrefix = (long)maxStalenessPrefix;
            }

            this.Inner.ConsistencyPolicy = policy;
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListConnectionStringsResult> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts.ListConnectionStringsAsync(this.ResourceGroupName,
                this.Name);
            return result != null ? new DatabaseAccountListConnectionStringsResultImpl(result) : null;
        }

        public async Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.RegenerateKeyAsync(this.ResourceGroupName, this.Name, KeyKind.Parse(keyKind));
        }

        public CosmosDBAccountImpl WithKind(string kind)
        {
            this.Inner.Kind = DatabaseAccountKind.Parse(kind);
            return this;
        }

        public CosmosDBAccountImpl WithEventualConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Eventual, 0, 0);
            return this;
        }

        public CosmosDBAccountImpl WithBoundedStalenessConsistency(long maxStalenessPrefix, int maxIntervalInSeconds)
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.BoundedStaleness,
                maxStalenessPrefix,
                maxIntervalInSeconds);
            return this;
        }

        public Models.DefaultConsistencyLevel DefaultConsistencyLevel()
        {
            if (this.Inner.ConsistencyPolicy == null)
            {
                throw new Exception("Consistency policy is missing!");
            }

            return this.Inner.ConsistencyPolicy.DefaultConsistencyLevel;
        }

        public IDatabaseAccountListConnectionStringsResult ListConnectionStrings()
        {
            return Extensions.Synchronize(() => this.ListConnectionStringsAsync());
        }

        public Models.ConsistencyPolicy ConsistencyPolicy()
        {
            return this.Inner.ConsistencyPolicy;
        }

        public CosmosDBAccountImpl WithoutReadReplication(Region region)
        {
            this.EnsureFailoverIsInitialized();
            for (int i = 1; i < this.failoverPolicies.Count; i++)
            {
                if (this.failoverPolicies[i].LocationName != null)
                {
                    string locName = this.failoverPolicies[i].LocationName.Replace(" ", "").ToLower();
                    if (locName.Equals(region.Name))
                    {
                        this.failoverPolicies.RemoveAt(i);
                    }
                }
            }

            return this;
        }

        public CosmosDBAccountImpl WithSessionConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Session, 0, 0);
            return this;
        }

        private void AddLocationsForParameters(HasLocation locationParameters, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.FailoverPolicy> failoverPolicies)
        {
            List<Models.Location> locations = new List<Models.Location>();
            if (failoverPolicies.Count > 0)
            {
                for (int i = 0; i < failoverPolicies.Count; i++)
                {
                    Models.FailoverPolicy policyInner = failoverPolicies[i];
                    Models.Location location = new Models.Location();
                    location.FailoverPriority = i;
                    location.LocationName = policyInner.LocationName;
                    locations.Add(location);
                }
            }
            else
            {
                Models.Location location = new Models.Location();
                location.FailoverPriority = 0;
                location.LocationName = locationParameters.Location;
                locations.Add(location);
            }

            locationParameters.Locations = locations;
        }

        public CosmosDBAccountImpl WithIpRangeFilter(string ipRangeFilter)
        {
            this.Inner.IpRangeFilter = ipRangeFilter;
            return this;
        }

        public CosmosDBAccountImpl WithWriteReplication(Region region)
        {
            Models.FailoverPolicy FailoverPolicy = new Models.FailoverPolicy();
            FailoverPolicy.LocationName = region.Name;
            this.hasFailoverPolicyChanges = true;
            this.failoverPolicies.Add(FailoverPolicy);
            return this;
        }

        public string DocumentEndpoint()
        {
            return this.Inner.DocumentEndpoint;
        }

        public IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> ReadableReplications()
        {
            return this.Inner.ReadLocations as IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location>;
        }

        protected override async Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountGetResultsInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.GetAsync(this.ResourceGroupName, this.Name);
        }

        public Models.DatabaseAccountOfferType DatabaseAccountOfferType()
        {
            return this.Inner.DatabaseAccountOfferType.GetValueOrDefault();
        }

        public void RegenerateKey(string keyKind)
        {
            Extensions.Synchronize(() => this.RegenerateKeyAsync(keyKind));
        }

        private static string FixDBName(string name)
        {
            return name.ToLower();
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTags(IDictionary<string, string> tags)
        {
            this.WithTags(tags);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTag(string key, string value)
        {
            this.WithTag(key, value);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithoutTag(string key)
        {
            this.WithoutTag(key);
            return this;
        }

        ///GENMHASH:199BC8B250DE6FDC60059ADB2A4D8A17:0D023FA55B68AD0828AD9BF823383A9A
        public IDatabaseAccountListReadOnlyKeysResult ListReadOnlyKeys()
        {
            return Extensions.Synchronize(() => this.ListReadOnlyKeysAsync());
        }

        ///GENMHASH:53B98D29180D0703E1A1842F17ACDE80:FC86BA20A774722CAD5A76DA690B6B40
        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.IDatabaseAccountListReadOnlyKeysResult> ListReadOnlyKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.DatabaseAccounts
                .ListReadOnlyKeysAsync(this.ResourceGroupName, this.Name);
            return result != null ? new DatabaseAccountListReadOnlyKeysResultImpl(result) : null;
        }

        public IEnumerable<ISqlDatabase> ListSqlDatabases()
        {
            return Extensions.Synchronize(() => this.ListSqlDatabasesAsync());
        }

        public async Task<IEnumerable<ISqlDatabase>> ListSqlDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.Manager.Inner.SqlResources
                .ListSqlDatabasesAsync(this.ResourceGroupName, this.Name);
            return result.Select(inner => new SqlDatabaseImpl(inner));
        }

        ///GENMHASH:6A08D79B3D058AD12B94D8E88D3A66BB:CBB08B5D2F8EBB6B1A4BE51DA2907810
        public CosmosDBAccountImpl WithDataModelGremlin()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableGremlin"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Graph");

            return this;
        }

        ///GENMHASH:34B523C69C7FD510214D27D478D971AA:49F5455D8963DDB2BE21EA8B38B4C7BE
        public CosmosDBAccountImpl WithDataModelCassandra()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableCassandra"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Cassandra");
            return this;
        }

        ///GENMHASH:FE98547B907685F667775CEF9663148D:443A834D31456201597F04A15B4BD4A4
        public CosmosDBAccountImpl WithDataModelMongoDB()
        {
            this.Inner.Kind = DatabaseAccountKind.MongoDB;

            return this;
        }

        ///GENMHASH:D21A1256B8AE75B30461590AB84F759B:5B9CF5267A2EC5C6DB95D90298E3ADB2
        public CosmosDBAccountImpl WithDataModelSql()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;

            return this;
        }

        ///GENMHASH:CA81479D1B8439CD804916091691404E:3032A4A8923DA7CE6CCD1FF98076F538
        public CosmosDBAccountImpl WithDataModelAzureTable()
        {
            this.Inner.Kind = DatabaseAccountKind.GlobalDocumentDB;
            List<Capability> capabilities = new List<Capability>();
            capabilities.Add(new Capability("EnableTable"));
            this.Inner.Capabilities = capabilities;
            this.WithTag("defaultExperience", "Table");

            return this;
        }

        ///GENMHASH:A86A41D6B877011AC6B43DCB0D23965B:1E42DEC842C982C7303E6EE753676F51
        public CosmosDBAccountImpl WithKind(DatabaseAccountKind kind, params Capability[] capabilities)
        {
            this.Inner.Kind = kind;
            this.Inner.Capabilities = capabilities;
            return this;
        }

        ///GENMHASH:35EB1A31F5F9EE9C1A764577CD186B0D:C38E77AA90C47C0D1306953EF1EEE431
        public IReadOnlyList<Models.Capability> Capabilities()
        {
            List<Capability> capabilities = new List<Capability>(this.Inner.Capabilities);
            return capabilities.AsReadOnly();
        }

        ///GENMHASH:AC3242CC7AFA5FD11163B235DA2E6D85:F7D80B9BD1E3B78FD1EE1DF1FBB4845E
        public CosmosDBAccountImpl WithVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            this.Inner.IsVirtualNetworkFilterEnabled = true;
            string vnetId = virtualNetworkId + "/subnets/" + subnetName;
            var internalMap = EnsureVirtualNetworkRules();
            if (!internalMap.ContainsKey(vnetId))
            {
                internalMap.Add(vnetId, new List<VirtualNetworkRule>());
            }
            internalMap[vnetId].Add(new VirtualNetworkRule() { Id = vnetId });
            return this;
        }

        ///GENMHASH:2BAA9926FD32E7ED76BE6DA4E3CFDF0A:EC13F18969F111A4EF37992607E9430C
        public CosmosDBAccountImpl WithVirtualNetworkRules(IList<Models.VirtualNetworkRule> virtualNetworkRules)
        {
            var vnetRules = EnsureVirtualNetworkRules();
            if (virtualNetworkRules == null || virtualNetworkRules.Count == 0)
            {
                vnetRules.Clear();
                this.Inner.IsVirtualNetworkFilterEnabled = false;
            }
            else
            {
                this.Inner.IsVirtualNetworkFilterEnabled = true;
                foreach (var vnetRule in virtualNetworkRules)
                {
                    if (!this.virtualNetworkRulesMap.ContainsKey(vnetRule.Id))
                    {
                        this.virtualNetworkRulesMap.Add(vnetRule.Id, new List<VirtualNetworkRule>());
                    }
                    this.virtualNetworkRulesMap[vnetRule.Id].Add(vnetRule);
                }
            }
            return this;
        }

        ///GENMHASH:17381C8EEA34CDB3DCBE083E7F6D6502:89110E5415CB9D8F19001F6DD8615C07
        public CosmosDBAccountImpl WithoutVirtualNetwork(string virtualNetworkId, string subnetName)
        {
            var vnetRules = EnsureVirtualNetworkRules();
            vnetRules.Remove(virtualNetworkId + "/subnets/" + subnetName);
            if (vnetRules.Count == 0)
            {
                this.Inner.IsVirtualNetworkFilterEnabled = false;
            }
            return this;
        }

        public CosmosDBAccountImpl WithMultipleWriteLocationsEnabled(bool enabled)
        {
            this.Inner.EnableMultipleWriteLocations = enabled;
            return this;
        }

        ///GENMHASH:ED2CFE8848802E73EC1E094FD7531ECC:49712209F38177A621F85B96C0B5A1BD
        public IReadOnlyList<Models.VirtualNetworkRule> VirtualNetworkRules()
        {
            List<VirtualNetworkRule> result = (this.Inner != null && this.Inner.VirtualNetworkRules != null) ? new List<VirtualNetworkRule>(this.Inner.VirtualNetworkRules) : new List<VirtualNetworkRule>();
            return result.AsReadOnly();
        }

        ///GENMHASH:9DD08936D3B4E402E37AEF19676FBBE5:B75CF3B3BDA8D4D5A2337A51BF9E22A0
        private Dictionary<string, List<Models.VirtualNetworkRule>> EnsureVirtualNetworkRules()
        {
            if (this.virtualNetworkRulesMap == null)
            {
                this.virtualNetworkRulesMap = new Dictionary<string, List<VirtualNetworkRule>>();
                if (this.Inner != null && this.Inner.VirtualNetworkRules != null)
                {
                    foreach (var item in this.Inner.VirtualNetworkRules)
                    {
                        if (!this.virtualNetworkRulesMap.ContainsKey(item.Id))
                        {
                            this.virtualNetworkRulesMap.Add(item.Id, new List<VirtualNetworkRule>());
                        }
                        this.virtualNetworkRulesMap[item.Id].Add(item);
                    }
                }
            }
            return this.virtualNetworkRulesMap;
        }

        ///GENMHASH:6E12523D3FA35427B421697F84BC8C8E:CF5AA1C3299F3EAB8439C499BFAD21B3
        public void OfflineRegion(Region region)
        {
            Extensions.Synchronize(() => this.OfflineRegionAsync(region));
        }

        ///GENMHASH:ABD34DADCC62B1C6C4CAC76E3F30BA2A:BC9F58EA7772977E5CC09E30FDDA0E5F
        public async Task OfflineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.OfflineRegionAsync(this.ResourceGroupName, this.Name, region.Name, cancellationToken);
        }

        ///GENMHASH:A81623860EADE07F6CC2D783FF2781AF:5E28B3B12A4E565FD3BC928F3675CF8A
        public void OnlineRegion(Region region)
        {
            Extensions.Synchronize(() => this.OnlineRegionAsync(region));
        }

        ///GENMHASH:0BDF69B81ED4468EAFAB0B382798913E:A9398126CC05684804C52BFD5F15265C
        public async Task OnlineRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.OnlineRegionAsync(this.ResourceGroupName, this.Name, region.Name, cancellationToken);
        }

        public bool CassandraConnectorEnabled()
        {
            return this.Inner.EnableCassandraConnector ?? false;
        }

        public ConnectorOffer CassandraConnectorOffer()
        {
            return this.Inner.ConnectorOffer;
        }

        public CosmosDBAccountImpl WithCassandraConnector(ConnectorOffer connectorOffer)
        {
            this.Inner.EnableCassandraConnector = true;
            this.Inner.ConnectorOffer = connectorOffer;
            return this;
        }

        public CosmosDBAccountImpl WithoutCassandraConnector()
        {
            this.Inner.EnableCassandraConnector = false;
            this.Inner.ConnectorOffer = null;
            return this;
        }

        public bool KeyBaseMetadataWriteAccessDisabled()
        {
            return this.Inner.DisableKeyBasedMetadataWriteAccess ?? false;
        }
        public CosmosDBAccountImpl WithDisableKeyBaseMetadataWriteAccess(bool disabled)
        {
            this.Inner.DisableKeyBasedMetadataWriteAccess = disabled;
            return this;
        }

        internal CosmosDBAccountImpl WithPrivateEndpointConnection(PrivateEndpointConnectionImpl privateEndpointConnection)
        {
            this.privateEndpointConnections.AddPrivateEndpointConnection(privateEndpointConnection);
            return this;
        }

        internal PrivateEndpointConnectionImpl DefineNewPrivateEndpointConnection(string name)
        {
            return this.privateEndpointConnections.Define(name);
        }

        internal PrivateEndpointConnectionImpl UpdatePrivateEndpointConnection(string name)
        {
            return this.privateEndpointConnections.Update(name);
        }

        public CosmosDBAccountImpl WithoutPrivateEndpointConnection(string name)
        {
            this.privateEndpointConnections.Remove(name);
            return this;
        }

        public IPrivateEndpointConnection GetPrivateEndpointConnection(string name)
        {
            return Extensions.Synchronize(() => this.GetPrivateEndpointConnectionAsync(name));
        }

        public async Task<IPrivateEndpointConnection> GetPrivateEndpointConnectionAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.privateEndpointConnections.GetImplAsync(name, cancellationToken);
        }

        public IReadOnlyDictionary<string, IPrivateEndpointConnection> ListPrivateEndpointConnection()
        {
            return Extensions.Synchronize(() => this.ListPrivateEndpointConnectionAsync());
        }

        public async Task<IReadOnlyDictionary<string, IPrivateEndpointConnection>> ListPrivateEndpointConnectionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var privateEndpointConnection = await this.privateEndpointConnections.AsMapAsync(cancellationToken);
            return privateEndpointConnection.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public IPrivateLinkResource GetPrivateLinkResource(string groupName)
        {
            return Extensions.Synchronize(() => this.GetPrivateLinkResourceAsync(groupName));
        }

        public async Task<IPrivateLinkResource> GetPrivateLinkResourceAsync(string groupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await this.Manager.Inner.PrivateLinkResources.GetAsync(ResourceGroupName, Name, groupName, cancellationToken);
            return new PrivateLinkResourceImpl(inner);
        }

        public IReadOnlyList<IPrivateLinkResource> ListPrivateLinkResources()
        {
            return Extensions.Synchronize(() => this.ListPrivateLinkResourcesAsync());
        }

        public async Task<IReadOnlyList<IPrivateLinkResource>> ListPrivateLinkResourcesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inners = await this.Manager.Inner.PrivateLinkResources.ListByDatabaseAccountAsync(ResourceGroupName, Name, cancellationToken);

            var result = new List<IPrivateLinkResource>();
            foreach (var inner in inners)
            {
                result.Add(new PrivateLinkResourceImpl(inner));
            }
            return result;
        }

        interface HasLocation
        {
            string Location { get; }
            IList<Location> Locations { get; set; }
        }

        public class CreateUpdateLocationParameters : HasLocation
        {
            private DatabaseAccountCreateUpdateParameters parameters;

            public CreateUpdateLocationParameters(DatabaseAccountCreateUpdateParameters createUpdateParameters)
            {
                parameters = createUpdateParameters;
            }

            public string Location
            {
                get
                {
                    return parameters.Location;
                }
            }

            public IList<Location> Locations
            {
                get
                {
                    return parameters.Locations;
                }
                set
                {
                    parameters.Locations = value;
                }
            }
        }

        public class UpdateLocationParameters : HasLocation
        {
            private DatabaseAccountUpdateParameters parameters;

            public UpdateLocationParameters(DatabaseAccountUpdateParameters updateParameters)
            {
                parameters = updateParameters;
            }

            public string Location
            {
                get
                {
                    return parameters.Location;
                }
            }

            public IList<Location> Locations
            {
                get
                {
                    return parameters.Locations;
                }
                set
                {
                    parameters.Locations = value;
                }
            }
        }
    }
}