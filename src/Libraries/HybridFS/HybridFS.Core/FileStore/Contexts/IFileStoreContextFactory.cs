namespace HybridFS.FileStore.Contexts
{
    public interface IFileStoreContextFactory
    {
        public FileStoreContext GetContext(long id);
    }
}
