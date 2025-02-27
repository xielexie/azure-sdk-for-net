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

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of GalleryImageVersion and their operations over a GalleryImage. </summary>
    public partial class GalleryImageVersionCollection : ArmCollection, IEnumerable<GalleryImageVersion>, IAsyncEnumerable<GalleryImageVersion>
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly GalleryImageVersionsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="GalleryImageVersionCollection"/> class for mocking. </summary>
        protected GalleryImageVersionCollection()
        {
        }

        /// <summary> Initializes a new instance of GalleryImageVersionCollection class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal GalleryImageVersionCollection(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new GalleryImageVersionsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        IEnumerator<GalleryImageVersion> IEnumerable<GalleryImageVersion>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<GalleryImageVersion> IAsyncEnumerable<GalleryImageVersion>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => GalleryImage.ResourceType;

        // Collection level operations.

        /// <summary> Create or update a gallery image version. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="galleryImageVersion"> Parameters supplied to the create or update gallery image version operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> or <paramref name="galleryImageVersion"/> is null. </exception>
        public virtual GalleryImageVersionCreateOrUpdateOperation CreateOrUpdate(string galleryImageVersionName, GalleryImageVersionData galleryImageVersion, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersionName == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersionName));
            }
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, galleryImageVersion, cancellationToken);
                var operation = new GalleryImageVersionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, galleryImageVersion).Request, response);
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

        /// <summary> Create or update a gallery image version. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="galleryImageVersion"> Parameters supplied to the create or update gallery image version operation. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> or <paramref name="galleryImageVersion"/> is null. </exception>
        public async virtual Task<GalleryImageVersionCreateOrUpdateOperation> CreateOrUpdateAsync(string galleryImageVersionName, GalleryImageVersionData galleryImageVersion, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (galleryImageVersionName == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersionName));
            }
            if (galleryImageVersion == null)
            {
                throw new ArgumentNullException(nameof(galleryImageVersion));
            }

            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, galleryImageVersion, cancellationToken).ConfigureAwait(false);
                var operation = new GalleryImageVersionCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, galleryImageVersion).Request, response);
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
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<GalleryImageVersion> Get(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.Get");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new GalleryImageVersion(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<GalleryImageVersion>> GetAsync(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.Get");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new GalleryImageVersion(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<GalleryImageVersion> GetIfExists(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, expand, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<GalleryImageVersion>(null, response.GetRawResponse())
                    : Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<GalleryImageVersion>> GetIfExistsAsync(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, galleryImageVersionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<GalleryImageVersion>(null, response.GetRawResponse())
                    : Response.FromValue(new GalleryImageVersion(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = GetIfExists(galleryImageVersionName, expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="galleryImageVersionName"> The name of the gallery image version to be retrieved. </param>
        /// <param name="expand"> The expand expression to apply on the operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string galleryImageVersionName, ReplicationStatusTypes? expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.CheckIfExists");
            scope.Start();
            try
            {
                if (galleryImageVersionName == null)
                {
                    throw new ArgumentNullException(nameof(galleryImageVersionName));
                }

                var response = await GetIfExistsAsync(galleryImageVersionName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List gallery image versions in a gallery image definition. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GalleryImageVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GalleryImageVersion> GetAll(CancellationToken cancellationToken = default)
        {
            Page<GalleryImageVersion> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllByGalleryImage(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GalleryImageVersion(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<GalleryImageVersion> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAllByGalleryImageNextPage(nextLink, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new GalleryImageVersion(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List gallery image versions in a gallery image definition. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GalleryImageVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GalleryImageVersion> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<GalleryImageVersion>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllByGalleryImageAsync(Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GalleryImageVersion(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<GalleryImageVersion>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("GalleryImageVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllByGalleryImageNextPageAsync(nextLink, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new GalleryImageVersion(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
        // public ArmBuilder<ResourceIdentifier, GalleryImageVersion, GalleryImageVersionData> Construct() { }
    }
}
