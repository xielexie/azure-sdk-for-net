// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of ExpressRouteCircuitAuthorization and their operations over a ExpressRouteCircuit. </summary>
    public partial class ExpressRouteCircuitAuthorizationCollection : ArmCollection, IEnumerable<ExpressRouteCircuitAuthorization>, IAsyncEnumerable<ExpressRouteCircuitAuthorization>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ExpressRouteCircuitAuthorizationsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ExpressRouteCircuitAuthorizationCollection"/> class for mocking. </summary>
        protected ExpressRouteCircuitAuthorizationCollection()
        {
        }

        /// <summary> Initializes a new instance of ExpressRouteCircuitAuthorizationCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExpressRouteCircuitAuthorizationCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ExpressRouteCircuitAuthorizationsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<ExpressRouteCircuitAuthorization> IEnumerable<ExpressRouteCircuitAuthorization>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ExpressRouteCircuitAuthorization> IAsyncEnumerable<ExpressRouteCircuitAuthorization>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ExpressRouteCircuit.ResourceType;

        // Collection level operations.

        /// <summary> Creates or updates an authorization in the specified express route circuit. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="authorizationParameters"> Parameters supplied to the create or update express route circuit authorization operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationName"/> or <paramref name="authorizationParameters"/> is null. </exception>
        public virtual ExpressRouteCircuitAuthorizationCreateOrUpdateOperation CreateOrUpdate(string authorizationName, ExpressRouteCircuitAuthorizationData authorizationParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (authorizationName == null)
            {
                throw new ArgumentNullException(nameof(authorizationName));
            }
            if (authorizationParameters == null)
            {
                throw new ArgumentNullException(nameof(authorizationParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, authorizationName, authorizationParameters, cancellationToken);
                var operation = new ExpressRouteCircuitAuthorizationCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, authorizationName, authorizationParameters).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates an authorization in the specified express route circuit. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="authorizationParameters"> Parameters supplied to the create or update express route circuit authorization operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationName"/> or <paramref name="authorizationParameters"/> is null. </exception>
        public async virtual Task<ExpressRouteCircuitAuthorizationCreateOrUpdateOperation> CreateOrUpdateAsync(string authorizationName, ExpressRouteCircuitAuthorizationData authorizationParameters, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (authorizationName == null)
            {
                throw new ArgumentNullException(nameof(authorizationName));
            }
            if (authorizationParameters == null)
            {
                throw new ArgumentNullException(nameof(authorizationParameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, authorizationName, authorizationParameters, cancellationToken).ConfigureAwait(false);
                var operation = new ExpressRouteCircuitAuthorizationCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, authorizationName, authorizationParameters).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExpressRouteCircuitAuthorization> Get(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.Get");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, authorizationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExpressRouteCircuitAuthorization(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExpressRouteCircuitAuthorization>> GetAsync(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.Get");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, authorizationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ExpressRouteCircuitAuthorization(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ExpressRouteCircuitAuthorization> GetIfExists(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetIfExists");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, authorizationName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ExpressRouteCircuitAuthorization>(null, response.GetRawResponse())
                    : Response.FromValue(new ExpressRouteCircuitAuthorization(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ExpressRouteCircuitAuthorization>> GetIfExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetIfExists");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, authorizationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ExpressRouteCircuitAuthorization>(null, response.GetRawResponse())
                    : Response.FromValue(new ExpressRouteCircuitAuthorization(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = GetIfExists(authorizationName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="authorizationName"> The name of the authorization. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string authorizationName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (authorizationName == null)
                {
                    throw new ArgumentNullException(nameof(authorizationName));
                }

                var response = await GetIfExistsAsync(authorizationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all authorizations in an express route circuit. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ExpressRouteCircuitAuthorization" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ExpressRouteCircuitAuthorization> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ExpressRouteCircuitAuthorization> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitAuthorization(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ExpressRouteCircuitAuthorization> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllNextPage(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitAuthorization(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets all authorizations in an express route circuit. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ExpressRouteCircuitAuthorization" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ExpressRouteCircuitAuthorization> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ExpressRouteCircuitAuthorization>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitAuthorization(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ExpressRouteCircuitAuthorization>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ExpressRouteCircuitAuthorizationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllNextPageAsync(nextLink, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ExpressRouteCircuitAuthorization(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, ExpressRouteCircuitAuthorization, ExpressRouteCircuitAuthorizationData> Construct() { }
    }
}
