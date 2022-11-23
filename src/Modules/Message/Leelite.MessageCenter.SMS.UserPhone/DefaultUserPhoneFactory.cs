using Leelite.Modules.MessageCenter.SMS;

namespace Leelite.Modules.MessageCenter.UserPhone
{
    public class DefaultUserPhoneFactory : IUserPhoneFactory
    {
        public string GetPhone(long userId)
        {
            return "15606402102";
        }
    }
}
