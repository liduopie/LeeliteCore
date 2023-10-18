using System.Collections.Generic;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Model;

using Microsoft.AspNetCore.Identity;

namespace Leelite.Identity.Models.UserTokenAgg
{
    public class UserToken : AggregateRoot<UserTokenKey>
    {
        /// <inheritdoc/>
        public override UserTokenKey Id { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that the token belongs to.
        /// </summary>
        public long UserId
        {
            get
            {
                return Id.UserId;
            }
            set
            {
                Id.UserId = value;
            }
        }

        /// <summary>
        /// Gets or sets the LoginProvider this token is from.
        /// </summary>
        public string LoginProvider
        {
            get
            {
                return Id.LoginProvider;
            }
            set
            {
                Id.LoginProvider = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        public string Name
        {
            get
            {
                return Id.Name;
            }
            set
            {
                Id.Name = value;
            }
        }

        /// <summary>
        /// Gets or sets the token value.
        /// </summary>
        [ProtectedPersonalData]
        public string Value { get; set; }
    }

    public class UserTokenKey : ValueObject<UserTokenKey>
    {
        /// <summary>
        /// Gets or sets the primary key of the user that the token belongs to.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the LoginProvider this token is from.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the name of the token.
        /// </summary>
        public string Name { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { UserId, LoginProvider };
        }
    }
}
