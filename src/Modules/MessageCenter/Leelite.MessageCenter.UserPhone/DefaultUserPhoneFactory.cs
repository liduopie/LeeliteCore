using Leelite.MessageCenter.SMS;

namespace Leelite.MessageCenter.UserPhone
{
    public class DefaultUserPhoneFactory : IUserPhoneFactory
    {
        public string GetPhone(long userId)
        {
            return "15606102";
        }
    }
}
