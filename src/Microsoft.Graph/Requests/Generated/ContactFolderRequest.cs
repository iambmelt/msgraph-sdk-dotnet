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
    /// The type ContactFolderRequest.
    /// </summary>
    public partial class ContactFolderRequest : BaseRequest, IContactFolderRequest
    {
        /// <summary>
        /// Constructs a new ContactFolderRequest.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        public ContactFolderRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options)
            : base(requestUrl, client, options)
        {
        }

        /// <summary>
        /// Creates the specified ContactFolder using PUT.
        /// </summary>
        /// <param name="contactFolderToCreate">The ContactFolder to create.</param>
        /// <returns>The created ContactFolder.</returns>
        public Task<ContactFolder> CreateAsync(ContactFolder contactFolderToCreate)
        {
            return this.CreateAsync(contactFolderToCreate, CancellationToken.None);
        }

        /// <summary>
        /// Creates the specified ContactFolder using PUT.
        /// </summary>
        /// <param name="contactFolderToCreate">The ContactFolder to create.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The created ContactFolder.</returns>
        public async Task<ContactFolder> CreateAsync(ContactFolder contactFolderToCreate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PUT";
            var newEntity = await this.SendAsync<ContactFolder>(contactFolderToCreate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Deletes the specified ContactFolder.
        /// </summary>
        /// <returns>The task to await.</returns>
        public Task DeleteAsync()
        {
            return this.DeleteAsync(CancellationToken.None);
        }

        /// <summary>
        /// Deletes the specified ContactFolder.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The task to await.</returns>
        public async Task DeleteAsync(CancellationToken cancellationToken)
        {
            this.Method = "DELETE";
            await this.SendAsync<ContactFolder>(null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified ContactFolder.
        /// </summary>
        /// <returns>The ContactFolder.</returns>
        public Task<ContactFolder> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        /// <summary>
        /// Gets the specified ContactFolder.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The ContactFolder.</returns>
        public async Task<ContactFolder> GetAsync(CancellationToken cancellationToken)
        {
            this.Method = "GET";
            var retrievedEntity = await this.SendAsync<ContactFolder>(null, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(retrievedEntity);
            return retrievedEntity;
        }

        /// <summary>
        /// Updates the specified ContactFolder using PATCH.
        /// </summary>
        /// <param name="contactFolderToUpdate">The ContactFolder to update.</param>
        /// <returns>The updated ContactFolder.</returns>
        public Task<ContactFolder> UpdateAsync(ContactFolder contactFolderToUpdate)
        {
            return this.UpdateAsync(contactFolderToUpdate, CancellationToken.None);
        }

        /// <summary>
        /// Updates the specified ContactFolder using PATCH.
        /// </summary>
        /// <param name="contactFolderToUpdate">The ContactFolder to update.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The updated ContactFolder.</returns>
        public async Task<ContactFolder> UpdateAsync(ContactFolder contactFolderToUpdate, CancellationToken cancellationToken)
        {
            this.ContentType = "application/json";
            this.Method = "PATCH";
            var updatedEntity = await this.SendAsync<ContactFolder>(contactFolderToUpdate, cancellationToken).ConfigureAwait(false);
            this.InitializeCollectionProperties(updatedEntity);
            return updatedEntity;
        }

        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        public IContactFolderRequest Expand(string value)
        {
            this.QueryOptions.Add(new QueryOption("$expand", value));
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IContactFolderRequest Select(string value)
        {
            this.QueryOptions.Add(new QueryOption("$select", value));
            return this;
        }

        /// <summary>
        /// Initializes any collection properties after deserialization, like next requests for paging.
        /// </summary>
        /// <param name="contactFolderToInitialize">The <see cref="ContactFolder"/> with the collection properties to initialize.</param>
        private void InitializeCollectionProperties(ContactFolder contactFolderToInitialize)
        {
        
            if (contactFolderToInitialize != null && contactFolderToInitialize.AdditionalData != null)
            {
        
                if (contactFolderToInitialize.Contacts != null && contactFolderToInitialize.Contacts.CurrentPage != null)
                {
                    contactFolderToInitialize.Contacts.AdditionalData = contactFolderToInitialize.AdditionalData;

                    object nextPageLink;
                    contactFolderToInitialize.AdditionalData.TryGetValue("contacts@odata.nextLink", out nextPageLink);
                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        contactFolderToInitialize.Contacts.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }
        
                if (contactFolderToInitialize.ChildFolders != null && contactFolderToInitialize.ChildFolders.CurrentPage != null)
                {
                    contactFolderToInitialize.ChildFolders.AdditionalData = contactFolderToInitialize.AdditionalData;

                    object nextPageLink;
                    contactFolderToInitialize.AdditionalData.TryGetValue("childFolders@odata.nextLink", out nextPageLink);
                    var nextPageLinkString = nextPageLink as string;

                    if (!string.IsNullOrEmpty(nextPageLinkString))
                    {
                        contactFolderToInitialize.ChildFolders.InitializeNextPageRequest(
                            this.Client,
                            nextPageLinkString);
                    }
                }
        
            }

        
        }
    }
}
