// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Represents an authorization requirements provider.
    /// </summary>
    public interface IAuthorizationRequirementsProvider
    {
        /// <summary>
        /// Gets the authorization requirements that correponds with a authorization
        /// data and the implemented logic.
        /// </summary>
        /// <param name="authorizeData">The authorization data.</param>
        /// <returns>Authorization requirements based on authorization data.</returns>
        Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(IAuthorizeData authorizeData);
    }
}
