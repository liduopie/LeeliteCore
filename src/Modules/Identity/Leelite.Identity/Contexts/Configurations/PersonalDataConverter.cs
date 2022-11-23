using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leelite.Identity.Contexts.Configurations
{
    public class PersonalDataConverter : ValueConverter<string, string>
    {
        public PersonalDataConverter(IPersonalDataProtector protector) : base(s => protector.Protect(s), s => protector.Unprotect(s), default)
        { }
    }
}
