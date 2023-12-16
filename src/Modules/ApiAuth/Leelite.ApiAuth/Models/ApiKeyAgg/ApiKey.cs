using System.Security.Claims;
using System.Text.Json;

using AspNetCore.Authentication.ApiKey;

using Leelite.Framework.Domain.Aggregate;

namespace Leelite.ApiAuth.Models.ApiKeyAgg
{
    public class ApiKey : AggregateRoot<long>, IApiKey
    {
        private List<Claim> _claims;

        public ApiKey() { }

        public ApiKey(string key, string owner, List<Claim> claims = null)
        {
            Key = key;
            OwnerName = owner;
            Claims = claims ?? new List<Claim>();
        }

        public long UserId { get; set; }
        public string Key { get; set; }
        public string OwnerName { get; set; }
        public IReadOnlyCollection<Claim> Claims
        {
            get { return _claims; }
            set { _claims = value.ToList(); }
        }

        public string ClaimData
        {
            get
            {
                var list = new List<string>();

                foreach (var item in _claims)
                {
                    list.Add(item.ToString());
                }

                return JsonSerializer.Serialize(list);
            }
            set
            {
                var strList = JsonSerializer.Deserialize<List<string>>(value);

                _claims = new List<Claim>();

                foreach (var item in strList)
                {
                    var arr = item.Split(":", StringSplitOptions.TrimEntries);

                    _claims.Add(new Claim(arr[0], arr[1]));
                }
            }
        }
    }
}
