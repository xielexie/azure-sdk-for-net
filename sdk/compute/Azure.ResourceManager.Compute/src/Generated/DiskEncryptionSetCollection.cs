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
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of DiskEncryptionSet and their operations over a ResourceGroup. </summary>
    public partial class DiskEncryptionSetCollection : ArmCollection, IEnumerable<DiskEncryptionSet>, IAsyncEnumerable<DiskEncryptionSet>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly DiskEncryptionSetsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="DiskEncryptionSetCollection"/> class for mocking. </summary>
        protected DiskEncryptionSetCollection()
        {
        }

        /// <summary> Initializes a new instance of DiskEncryptionSetCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DiskEncryptionSetCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new DiskEncryptionSetsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<DiskEncryptionSet> IEnumerable<DiskEncryptionSet>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DiskEncryptionSet> IAsyncEnumerable<DiskEncryptionSet>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroup.ResourceType;

        // Collection level operations.

        /// <summary> Creates or updates a disk encryption set. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskEncryptionSet"> disk encryption set object supplied in the body of the Put disk encryption set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskEncryptionSetName"/> or <paramref name="diskEncryptionSet"/> is null. </exception>
        public virtual DiskEncryptionSetCreateOrUpdateOperation CreateOrUpdate(string diskEncryptionSetName, DiskEncryptionSetData diskEncryptionSet, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskEncryptionSetName == null)
            {
                throw new ArgumentNullException(nameof(diskEncryptionSetName));
            }
            if (diskEncryptionSet == null)
            {
                throw new ArgumentNullException(nameof(diskEncryptionSet));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, diskEncryptionSetName, diskEncryptionSet, cancellationToken);
                var operation = new DiskEncryptionSetCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, diskEncryptionSetName, diskEncryptionSet).Request, response);
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

        /// <summary> Creates or updates a disk encryption set. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="diskEncryptionSet"> disk encryption set object supplied in the body of the Put disk encryption set operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="diskEncryptionSetName"/> or <paramref name="diskEncryptionSet"/> is null. </exception>
        public async virtual Task<DiskEncryptionSetCreateOrUpdateOperation> CreateOrUpdateAsync(string diskEncryptionSetName, DiskEncryptionSetData diskEncryptionSet, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (diskEncryptionSetName == null)
            {
                throw new ArgumentNullException(nameof(diskEncryptionSetName));
            }
            if (diskEncryptionSet == null)
            {
                throw new ArgumentNullException(nameof(diskEncryptionSet));
            }

            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, diskEncryptionSetName, diskEncryptionSet, cancellationToken).ConfigureAwait(false);
                var operation = new DiskEncryptionSetCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, diskEncryptionSetName, diskEncryptionSet).Request, response);
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
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<DiskEncryptionSet> Get(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.Get");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, diskEncryptionSetName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DiskEncryptionSet(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<DiskEncryptionSet>> GetAsync(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.Get");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, diskEncryptionSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DiskEncryptionSet(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<DiskEncryptionSet> GetIfExists(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetIfExists");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, diskEncryptionSetName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<DiskEncryptionSet>(null, response.GetRawResponse())
                    : Response.FromValue(new DiskEncryptionSet(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<DiskEncryptionSet>> GetIfExistsAsync(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetIfExists");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, diskEncryptionSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<DiskEncryptionSet>(null, response.GetRawResponse())
                    : Response.FromValue(new DiskEncryptionSet(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = GetIfExists(diskEncryptionSetName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can&apos;t be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (diskEncryptionSetName == null)
                {
                    throw new ArgumentNullException(nameof(diskEncryptionSetName));
                }

                var response = await GetIfExistsAsync(diskEncryptionSetName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all the disk encryption sets under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskEncryptionSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DiskEncryptionSet> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DiskEncryptionSet> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskEncryptionSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DiskEncryptionSet> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskEncryptionSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists all the disk encryption sets under a resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskEncryptionSet" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DiskEncryptionSet> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DiskEncryptionSet>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskEncryptionSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DiskEncryptionSet>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DiskEncryptionSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DiskEncryptionSet" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskEncryptionSet.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContext(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DiskEncryptionSet" /> for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="expand"> Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DiskEncryptionSetCollection.GetAllAsGenericResources");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DiskEncryptionSet.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.GetAtContextAsync(Parent as ResourceGroup, filters, expand, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, DiskEncryptionSet, DiskEncryptionSetData> Construct() { }
    }
}
