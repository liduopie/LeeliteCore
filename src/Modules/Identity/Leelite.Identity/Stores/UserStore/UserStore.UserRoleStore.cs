using System.Globalization;

using Leelite.Identity.Models.RoleAgg;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.Models.UserRoleAgg;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Identity.Stores.UserStore
{
    public partial class UserStore : IUserRoleStore<User>
	{
		private DbSet<Role> Roles { get { return Context.Set<Role>(); } }
		private DbSet<UserRole> UserRoles { get { return Context.Set<UserRole>(); } }

		/// <summary>
		/// Adds the given <paramref name="roleName"/> to the specified <paramref name="user"/>.
		/// </summary>
		/// <param name="user">The user to add the role to.</param>
		/// <param name="roleName">The role to add.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
		public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			ArgumentNullException.ThrowIfNull(user);
			if (string.IsNullOrWhiteSpace(roleName))
			{
				throw new ArgumentException(Resources.ValueCannotBeNullOrEmpty, nameof(roleName));
			}
			var roleEntity = await FindRoleAsync(roleName, cancellationToken);
			if (roleEntity == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RoleNotFound, roleName));
			}
			UserRoles.Add(CreateUserRole(user, roleEntity));
		}

		/// <summary>
		/// Retrieves the roles the specified <paramref name="user"/> is a member of.
		/// </summary>
		/// <param name="user">The user whose roles should be retrieved.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>A <see cref="Task{TResult}"/> that contains the roles the user is a member of.</returns>
		public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			ArgumentNullException.ThrowIfNull(user);
			var userId = user.Id;
			var query = from userRole in UserRoles
						join role in Roles on userRole.RoleId equals role.Id
						where userRole.UserId.Equals(userId)
						select role.Name;
			return await query.ToListAsync(cancellationToken);
		}

		/// <summary>
		/// Retrieves all users in the specified role.
		/// </summary>
		/// <param name="roleName">The role whose users should be retrieved.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>
		/// The <see cref="Task"/> contains a list of users, if any, that are in the specified role.
		/// </returns>
		public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			ArgumentException.ThrowIfNullOrEmpty(roleName);

			var role = await FindRoleAsync(roleName, cancellationToken);

			if (role != null)
			{
				var query = from userrole in UserRoles
							join user in Users on userrole.UserId equals user.Id
							where userrole.RoleId.Equals(role.Id)
							select user;

				return await query.ToListAsync(cancellationToken);
			}
			return new List<User>();
		}

		/// <summary>
		/// Returns a flag indicating if the specified user is a member of the give <paramref name="roleName"/>.
		/// </summary>
		/// <param name="user">The user whose role membership should be checked.</param>
		/// <param name="roleName">The role to check membership of</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>A <see cref="Task{TResult}"/> containing a flag indicating if the specified user is a member of the given group. If the
		/// user is a member of the group the returned value with be true, otherwise it will be false.</returns>
		public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			ArgumentNullException.ThrowIfNull(user);
			if (string.IsNullOrWhiteSpace(roleName))
			{
				throw new ArgumentException(Resources.ValueCannotBeNullOrEmpty, nameof(roleName));
			}
			var role = await FindRoleAsync(roleName, cancellationToken);
			if (role != null)
			{
				var userRole = await FindUserRoleAsync(user.Id, role.Id, cancellationToken);
				return userRole != null;
			}
			return false;
		}

		/// <summary>
		/// Removes the given <paramref name="roleName"/> from the specified <paramref name="user"/>.
		/// </summary>
		/// <param name="user">The user to remove the role from.</param>
		/// <param name="roleName">The role to remove.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
		public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			ArgumentNullException.ThrowIfNull(user);
			if (string.IsNullOrWhiteSpace(roleName))
			{
				throw new ArgumentException(Resources.ValueCannotBeNullOrEmpty, nameof(roleName));
			}
			var roleEntity = await FindRoleAsync(roleName, cancellationToken);
			if (roleEntity != null)
			{
				var userRole = await FindUserRoleAsync(user.Id, roleEntity.Id, cancellationToken);
				if (userRole != null)
				{
					UserRoles.Remove(userRole);
				}
			}
		}

		/// <summary>
		/// Return a role with the normalized name if it exists.
		/// </summary>
		/// <param name="normalizedRoleName">The normalized role name.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>The role if it exists.</returns>
		protected Task<Role> FindRoleAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			return Roles.SingleOrDefaultAsync(r => r.NormalizedName == normalizedRoleName, cancellationToken);
		}

		/// <summary>
		/// Return a user role for the userId and roleId if it exists.
		/// </summary>
		/// <param name="userId">The user's id.</param>
		/// <param name="roleId">The role's id.</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
		/// <returns>The user role if it exists.</returns>
		protected Task<UserRole> FindUserRoleAsync(long userId, int roleId, CancellationToken cancellationToken)
		{
			return UserRoles.FindAsync(new object[] { userId, roleId }, cancellationToken).AsTask();
		}

		/// <summary>
		/// Called to create a new instance of a <see cref="IdentityUserRole{TKey}"/>.
		/// </summary>
		/// <param name="user">The associated user.</param>
		/// <param name="role">The associated role.</param>
		/// <returns></returns>
		protected virtual UserRole CreateUserRole(User user, Role role)
		{
			return new UserRole()
			{
				UserId = user.Id,
				RoleId = role.Id
			};
		}

	}
}
