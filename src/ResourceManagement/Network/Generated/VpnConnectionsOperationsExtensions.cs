// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VpnConnectionsOperations.
    /// </summary>
    public static partial class VpnConnectionsOperationsExtensions
    {
            /// <summary>
            /// Retrieves the details of a vpn connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='connectionName'>
            /// The name of the vpn connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VpnConnectionInner> GetAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, gatewayName, connectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a vpn connection to a scalable vpn gateway if it doesn't exist else
            /// updates the existing connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='connectionName'>
            /// The name of the connection.
            /// </param>
            /// <param name='vpnConnectionParameters'>
            /// Parameters supplied to create or Update a VPN Connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VpnConnectionInner> CreateOrUpdateAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, string connectionName, VpnConnectionInner vpnConnectionParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, gatewayName, connectionName, vpnConnectionParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a vpn connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='connectionName'>
            /// The name of the connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, gatewayName, connectionName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Retrieves all vpn connections for a particular virtual wan vpn gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<VpnConnectionInner>> ListByVpnGatewayAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByVpnGatewayWithHttpMessagesAsync(resourceGroupName, gatewayName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a vpn connection to a scalable vpn gateway if it doesn't exist else
            /// updates the existing connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='connectionName'>
            /// The name of the connection.
            /// </param>
            /// <param name='vpnConnectionParameters'>
            /// Parameters supplied to create or Update a VPN Connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VpnConnectionInner> BeginCreateOrUpdateAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, string connectionName, VpnConnectionInner vpnConnectionParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, gatewayName, connectionName, vpnConnectionParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a vpn connection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name of the VpnGateway.
            /// </param>
            /// <param name='gatewayName'>
            /// The name of the gateway.
            /// </param>
            /// <param name='connectionName'>
            /// The name of the connection.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IVpnConnectionsOperations operations, string resourceGroupName, string gatewayName, string connectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, gatewayName, connectionName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Retrieves all vpn connections for a particular virtual wan vpn gateway.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<VpnConnectionInner>> ListByVpnGatewayNextAsync(this IVpnConnectionsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByVpnGatewayNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
