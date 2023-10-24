namespace Leelite.MessageCenter.UniPush
{
    public interface IUserClientIdFactory
    {
        public string GetClientId(long userId);
    }
}
