// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class to add extension methods to Tenant. </summary>
    public static partial class TenantExtensions
    {
        #region Deployment
        /// <summary> Gets an object representing a Deployment along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Deployment" /> object. </returns>
        public static Deployment GetDeployment(this Tenant tenant, ResourceIdentifier id)
        {
            return new Deployment(tenant, id);
        }
        #endregion

        #region DeploymentOperation
        /// <summary> Gets an object representing a DeploymentOperation along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeploymentOperation" /> object. </returns>
        public static DeploymentOperation GetDeploymentOperation(this Tenant tenant, ResourceIdentifier id)
        {
            return new DeploymentOperation(tenant, id);
        }
        #endregion
    }
}
