// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Infrastructure class which allows an <see cref="IAuthorizeData"/> to
    /// be its own <see cref="IAuthorizationRequirementsProvider"/>.
    /// </summary>
    public class PassThroughAuthorizationRequirementsProvider : IAuthorizationRequirementsProvider
    {
        /// <summary>
        /// Makes a decision if authorization data is allowed.
        /// </summary>
        /// <param name="authorizeData">The autorization data.</param>
        /// <returns>The requirements returned by the proper authorization data.</returns>
        public async Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(IAuthorizeData authorizeData)
        {
            if (authorizeData is IAuthorizationRequirementsProvider requirementsProvider)
            {
                return await requirementsProvider.GetRequirementsAsync(authorizeData);
            }

            return await AuthorizationRequirementsProvider.EmptyResult;
        }
    }
}
