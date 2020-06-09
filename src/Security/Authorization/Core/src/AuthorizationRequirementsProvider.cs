// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authorization
{
    /// <summary>
    /// Base class for authorization requirements provider.
    /// </summary>
    public abstract class AuthorizationRequirementsProvider : IAuthorizationRequirementsProvider
    {
        /// <summary>
        /// The default empty result value. Used for performance.
        /// </summary>
        public static readonly Task<IEnumerable<IAuthorizationRequirement>> EmptyResult
            = Task.FromResult(Enumerable.Empty<IAuthorizationRequirement>());

        /// <summary>
        /// Helper to normalize result.
        /// </summary>
        /// <param name="requirements">Requirements instances.</param>
        /// <returns>Normalized result.</returns>
        public static Task<IEnumerable<IAuthorizationRequirement>> Result(params IAuthorizationRequirement[] requirements)
        {
            return Task.FromResult((IEnumerable<IAuthorizationRequirement>)requirements);
        }

        /// <inheritdoc />
        public abstract Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(IAuthorizeData authorizeData);
    }

    /// <summary>
    /// Base class for authorization requirements provider that need to be called for a specific authorization data type.
    /// </summary>
    /// <typeparam name="TAuthorizeData">The type of the authorization data to handle.</typeparam>
    public abstract class AuthorizationRequirementsProvider<TAuthorizeData> : AuthorizationRequirementsProvider
        where TAuthorizeData : IAuthorizeData
    {
        /// <summary>
        /// Makes a decision if authorization data is allowed.
        /// </summary>
        /// <param name="authorizeData">The authorization data.</param>
        /// <returns>Authorization requiments based on authorization data.</returns>
        public override async Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(IAuthorizeData authorizeData)
        {
            if (authorizeData is TAuthorizeData allowedAuthorizeData)
            {
                return await GetRequirementsAsync(allowedAuthorizeData);
            }

            return await EmptyResult;
        }

        /// <inheritdoc cref="IAuthorizationRequirementsProvider.GetRequirementsAsync(IAuthorizeData)" />
        protected abstract Task<IEnumerable<IAuthorizationRequirement>> GetRequirementsAsync(TAuthorizeData authorizeData);
    }
}
