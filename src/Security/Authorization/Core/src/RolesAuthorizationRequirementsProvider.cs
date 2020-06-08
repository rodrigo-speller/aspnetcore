// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Implements the <see cref="IAuthorizationRequirementsProvider"/> that interprets
    /// the <see cref="IAuthorizeData.Roles"/> value to create the related
    /// <see cref="RolesAuthorizationRequirement"/>.
    /// </summary>
    public class RolesAuthorizationRequirementsProvider : IAuthorizationRequirementsProvider
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(IAuthorizeData authorizeData)
        {
            var rolesSplit = authorizeData?.Roles?.Split(',');
            if (rolesSplit?.Length > 0)
            {
                var trimmedRolesSplit = rolesSplit.Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim());
                return new[] { new RolesAuthorizationRequirement(trimmedRolesSplit.ToArray()) };
            }

            return await AuthorizationRequirementsProvider.EmptyResult;
        }
    }
}
