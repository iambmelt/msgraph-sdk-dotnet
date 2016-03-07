// ------------------------------------------------------------------------------
//  Copyright (c) 2016 Microsoft Corporation
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
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
    /// The type DirectoryObjectGetMemberGroupsRequest.
    /// </summary>
    public partial class DirectoryObjectGetMemberGroupsRequest : BaseRequest, IDirectoryObjectGetMemberGroupsRequest
    {
    
        /// <summary>
        /// Constructs a new DirectoryObjectGetMemberGroupsRequest.
        /// </summary>
        public DirectoryObjectGetMemberGroupsRequest(
            string requestUrl,
            IBaseClient client,
            IList<Option> options,
            bool? securityEnabledOnly = null)
            : base(requestUrl, client, options)
        {
    
            this.Method = "POST";
            this.ContentType = "application/json";
            this.RequestBody = new DirectoryObjectGetMemberGroupsRequestBody();
            this.RequestBody.SecurityEnabledOnly = securityEnabledOnly;
    
        }
    
        /// <summary>
        /// Gets the request body.
        /// </summary>
        public DirectoryObjectGetMemberGroupsRequestBody RequestBody { get; private set; }
    
        /// <summary>
        /// Issues the POST request.
        /// </summary>
        public Task<IEnumerable<String>> PostAsync()
        {
            return this.PostAsync(HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }
        
        /// <summary>
        /// Issues the POST request.
        /// </summary>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>TheIEnumerable<String></returns>
        public Task<IEnumerable<String>> PostAsync(HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
    
            return this.SendAsync<IEnumerable<String>>(this.RequestBody, completionOption, cancellationToken);
    
        }
    
        /// <summary>
        /// Adds the specified expand value to the request.
        /// </summary>
        /// <param name="value">The expand value.</param>
        /// <returns>The request object to send.</returns>
        public IDirectoryObjectGetMemberGroupsRequest Expand(string value)
        {
            this.QueryOptions.Add(new QueryOption("$expand", value));
            return this;
        }

        /// <summary>
        /// Adds the specified select value to the request.
        /// </summary>
        /// <param name="value">The select value.</param>
        /// <returns>The request object to send.</returns>
        public IDirectoryObjectGetMemberGroupsRequest Select(string value)
        {
            this.QueryOptions.Add(new QueryOption("$select", value));
            return this;
        }

        /// <summary>
        /// Adds the specified top value to the request.
        /// </summary>
        /// <param name="value">The top value.</param>
        /// <returns>The request object to send.</returns>
        public IDirectoryObjectGetMemberGroupsRequest Top(int value)
        {
            this.QueryOptions.Add(new QueryOption("$top", value.ToString()));
            return this;
        }
    
    }
}