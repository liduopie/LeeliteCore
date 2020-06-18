namespace System.Runtime.Loader
{
    public class CollectibleAssemblyLoadContext : AssemblyLoadContext
    {
        public CollectibleAssemblyLoadContext() : base("Modules", isCollectible: true) { }
    }
}
