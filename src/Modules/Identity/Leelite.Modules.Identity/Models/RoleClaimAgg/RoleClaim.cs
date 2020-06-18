using System.Security.Claims;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Modules.Identity.Models.RoleClaimAgg
{
    /// <summary>
    /// Represents a claim that is granted to all users within a role.
    /// </summary>
    public class RoleClaim : AggregateRoot<int>
    {
        /// <summary>
        /// Gets or sets the of the primary key of the role associated with this claim.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the claim type for this claim.
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// Gets or sets the claim value for this claim.
        /// </summary>
        public string ClaimValue { get; set; }

        /// <summary>
        /// Constructs a new claim with the type and value.
        /// </summary>
        /// <returns>The <see cref="Claim"/> that was produced.</returns>
        public virtual Claim ToClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }

        /// <summary>
        /// Initializes by copying ClaimType and ClaimValue from the other claim.
        /// </summary>
        /// <param name="other">The claim to initialize from.</param>
        public virtual void InitializeFromClaim(Claim other)
        {
            ClaimType = other?.Type;
            ClaimValue = other?.Value;
        }
    }
}
