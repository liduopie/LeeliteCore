using System.Threading;
using System.Threading.Tasks;
using Leelite.Modules.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Stores.UserStore
{
    public partial class UserStore : IUserAuthenticatorKeyStore<User>
    {
        private const string InternalLoginProvider = "[AspNetUserStore]";
        private const string AuthenticatorKeyTokenName = "AuthenticatorKey";

        /// <summary>
        /// Get the authenticator key for the specified <paramref name="user" />.
        /// </summary>
        /// <param name="user">The user whose security stamp should be set.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing the security stamp for the specified <paramref name="user"/>.</returns>
        public virtual Task<string> GetAuthenticatorKeyAsync(User user, CancellationToken cancellationToken)
            => GetTokenAsync(user, InternalLoginProvider, AuthenticatorKeyTokenName, cancellationToken);

        /// <summary>
        /// Sets the authenticator key for the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The user whose authenticator key should be set.</param>
        /// <param name="key">The authenticator key to set.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
        public virtual Task SetAuthenticatorKeyAsync(User user, string key, CancellationToken cancellationToken)
            => SetTokenAsync(user, InternalLoginProvider, AuthenticatorKeyTokenName, key, cancellationToken);
    }
}
