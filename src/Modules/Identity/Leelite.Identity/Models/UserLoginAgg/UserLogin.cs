using System.Collections.Generic;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Model;

namespace Leelite.Identity.Models.UserLoginAgg
{

    /// <summary>
    /// Represents a login and its associated provider for a user.
    /// </summary>
    public class UserLogin : AggregateRoot<UserLoginKey>
    {
        private string _loginProvider;
        private string _providerKey;

        public override UserLoginKey Id
        {
            get
            {
                return new UserLoginKey()
                {
                    LoginProvider = _loginProvider,
                    ProviderKey = _providerKey
                };
            }
            set
            {
                _loginProvider = value.LoginProvider;
                _providerKey = value.ProviderKey;
            }
        }

        /// <summary>
        /// Gets or sets the friendly name used in a UI for this login.
        /// </summary>
        public string ProviderDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user associated with this login.
        /// </summary>
        public long UserId { get; set; }
    }

    public class UserLoginKey : ValueObject<UserLoginKey>
    {
        /// <summary>
        /// Gets or sets the login provider for the login (e.g. facebook, google)
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the unique provider identifier for this login.
        /// </summary>
        public string ProviderKey { get; set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { LoginProvider, ProviderKey };
        }
    }
}
