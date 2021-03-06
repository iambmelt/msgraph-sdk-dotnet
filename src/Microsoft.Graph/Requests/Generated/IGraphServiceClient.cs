// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// **NOTE** This file was generated by a tool and any changes will be overwritten.


namespace Microsoft.Graph
{

    /// <summary>
    /// The interface IGraphServiceClient.
    /// </summary>
    public partial interface IGraphServiceClient : IBaseClient
    {
    
        /// <summary>
        /// Gets the GraphServiceDirectoryObjects request builder.
        /// </summary>
        IGraphServiceDirectoryObjectsCollectionRequestBuilder DirectoryObjects { get; }
    
        /// <summary>
        /// Gets the GraphServiceDevices request builder.
        /// </summary>
        IGraphServiceDevicesCollectionRequestBuilder Devices { get; }
    
        /// <summary>
        /// Gets the GraphServiceGroups request builder.
        /// </summary>
        IGraphServiceGroupsCollectionRequestBuilder Groups { get; }
    
        /// <summary>
        /// Gets the GraphServiceDirectoryRoles request builder.
        /// </summary>
        IGraphServiceDirectoryRolesCollectionRequestBuilder DirectoryRoles { get; }
    
        /// <summary>
        /// Gets the GraphServiceDirectoryRoleTemplates request builder.
        /// </summary>
        IGraphServiceDirectoryRoleTemplatesCollectionRequestBuilder DirectoryRoleTemplates { get; }
    
        /// <summary>
        /// Gets the GraphServiceOrganization request builder.
        /// </summary>
        IGraphServiceOrganizationCollectionRequestBuilder Organization { get; }
    
        /// <summary>
        /// Gets the GraphServiceSubscribedSkus request builder.
        /// </summary>
        IGraphServiceSubscribedSkusCollectionRequestBuilder SubscribedSkus { get; }
    
        /// <summary>
        /// Gets the GraphServiceUsers request builder.
        /// </summary>
        IGraphServiceUsersCollectionRequestBuilder Users { get; }
    
        /// <summary>
        /// Gets the GraphServiceDrives request builder.
        /// </summary>
        IGraphServiceDrivesCollectionRequestBuilder Drives { get; }
    
        /// <summary>
        /// Gets the GraphServiceSubscriptions request builder.
        /// </summary>
        IGraphServiceSubscriptionsCollectionRequestBuilder Subscriptions { get; }
    
        /// <summary>
        /// Gets the GraphServiceMe request builder.
        /// </summary>
        IUserRequestBuilder Me { get; }
    
        /// <summary>
        /// Gets the GraphServiceDrive request builder.
        /// </summary>
        IDriveRequestBuilder Drive { get; }
    
    }
}
