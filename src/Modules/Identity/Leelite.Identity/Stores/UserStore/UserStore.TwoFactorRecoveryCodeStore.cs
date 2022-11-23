using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Leelite.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Identity.Stores.UserStore
{
    public partial class UserStore : IUserTwoFactorRecoveryCodeStore<User>
    {
        private const string RecoveryCodeTokenName = "RecoveryCodes";

        /// <summary>
        /// Returns how many recovery code are still valid for a user.
        /// </summary>
        /// <param name="user">The user who owns the recovery code.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The number of valid recovery codes for the user..</returns>
        public virtual async Task<int> CountCodesAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var mergedCodes = await GetTokenAsync(user, InternalLoginProvider, RecoveryCodeTokenName, cancellationToken) ?? "";
            if (mergedCodes.Length > 0)
            {
                return mergedCodes.Split(';').Length;
            }
            return 0;
        }

        /// <summary>
        /// Returns whether a recovery code is valid for a user. Note: recovery codes are only valid
        /// once, and will be invalid after use.
        /// </summary>
        /// <param name="user">The user who owns the recovery code.</param>
        /// <param name="code">The recovery code to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>True if the recovery code was found for the user.</returns>
        public virtual async Task<bool> RedeemCodeAsync(User user, string code, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var mergedCodes = await GetTokenAsync(user, InternalLoginProvider, RecoveryCodeTokenName, cancellationToken) ?? "";
            var splitCodes = mergedCodes.Split(';');
            if (splitCodes.Contains(code))
            {
                var updatedCodes = new List<string>(splitCodes.Where(s => s != code));
                await ReplaceCodesAsync(user, updatedCodes, cancellationToken);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Updates the recovery codes for the user while invalidating any previous recovery codes.
        /// </summary>
        /// <param name="user">The user to store new recovery codes for.</param>
        /// <param name="recoveryCodes">The new recovery codes for the user.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
        /// <returns>The new recovery codes for the user.</returns>
        public virtual Task ReplaceCodesAsync(User user, IEnumerable<string> recoveryCodes, CancellationToken cancellationToken)
        {
            var mergedCodes = string.Join(";", recoveryCodes);
            return SetTokenAsync(user, InternalLoginProvider, RecoveryCodeTokenName, mergedCodes, cancellationToken);
        }
    }
}
