namespace Leelite.Modules.MessageCenter.SMS
{
    public interface IUserPhoneFactory
    {
        public string GetPhone(long userId);
    }
}
