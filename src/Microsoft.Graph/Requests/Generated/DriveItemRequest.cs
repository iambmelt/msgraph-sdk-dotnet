// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.


namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The type DriveItemRequest.
    /// </summary>
    public partial class DriveItemRequest : BaseRequest, IDriveItemRequest
    {
        /// <summary>
        /// Constructs a new DriveItemRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public DriveItemRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified DriveItem using PUT.
        /// </summary>
        /// <param name="driveItemToCreate">The DriveItem to create.</param>
        /// <returns>The created DriveItem.</returns>
        public Task<DriveItem> CreateAsync(DriveItem driveItemToCreate)
        {
            return this.CreateAsync(driveItemToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified DriveItem using PUT.
        /// </summary>
        /// <param name="driveItemToCreate">The DriveItem to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created DriveItem.</returns>
        public async Task<DriveItem> CreateAsync(DriveItem driveItemToCreate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PUT";
            var newEntity = await this.SendAsync<DriveItem>(driveItemToCreate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified DriveItem.
        /// </summary>
        /// <returns>The task to await.</returns>
        public Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified DriveItem.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async Task DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = "DELETE";
            await this.SendAsync<DriveItem>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified DriveItem.
        /// </summary>
        /// <returns>The DriveItem.</returns>
        public Task<DriveItem> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified DriveItem.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The DriveItem.</returns>
        public async Task<DriveItem> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<DriveItem>(null, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(retrievedEntity);
            return retrievedEntity;
        }

        /// <summary>
        /// Updates the specified DriveItem using PATCH.
        /// </summary>
        /// <param name="driveItemToUpdate">The DriveItem to update.</param>
        /// <returns>The updated DriveItem.</returns>
        public Task<DriveItem> UpdateAsync(DriveItem driveItemToUpdate)
        {
            return this.UpdateAsync(driveItemToUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified DriveItem using PATCH.
        /// </summary>
        /// <param name="driveItemToUpdate">The DriveItem to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated DriveItem.</returns>
        public async Task<DriveItem> UpdateAsync(DriveItem driveItemToUpdate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PATCH";
            var updatedEntity = await this.SendAsync<DriveItem>(driveItemToUpdate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(updatedEntity);
            return updatedEntity;
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        public IDriveItemRequest Expand(string value)
        {
            this.QueryOptions.Add(new QueryOption("$expand", value));
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IDriveItemRequest Select(string value)
        {
            this.QueryOptions.Add(new QueryOption("$select", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="driveItemToInitialize">The <see cref="DriveItem"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(DriveItem driveItemToInitialize)
        {
        
            if (driveItemToInitialize != null && driveItemToInitialize.AdditionalData != null)
            {
        
                if (driveItemToInitialize.Permissions != null && driveItemToInitialize.Permissions.CurrentPage != null)
                {
                    driveItemToInitialize.Permissions.AdditionalData = driveItemToInitialize.AdditionalData;

                    object nextPageLink;
                    driveItemToInitialize.AdditionalData.TryGetValue("permissions@odata.nextLink", out nextPageLink);
                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        driveItemToInitialize.Permissions.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }
        
                if (driveItemToInitialize.Children != null && driveItemToInitialize.Children.CurrentPage != null)
                {
                    driveItemToInitialize.Children.AdditionalData = driveItemToInitialize.AdditionalData;

                    object nextPageLink;
                    driveItemToInitialize.AdditionalData.TryGetValue("children@odata.nextLink", out nextPageLink);
                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        driveItemToInitialize.Children.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }
        
                if (driveItemToInitialize.Thumbnails != null && driveItemToInitialize.Thumbnails.CurrentPage != null)
                {
                    driveItemToInitialize.Thumbnails.AdditionalData = driveItemToInitialize.AdditionalData;

                    object nextPageLink;
                    driveItemToInitialize.AdditionalData.TryGetValue("thumbnails@odata.nextLink", out nextPageLink);
                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        driveItemToInitialize.Thumbnails.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }
        
            }

        
        }
    }
}
