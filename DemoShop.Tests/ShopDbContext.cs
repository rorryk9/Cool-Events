namespace CoolEvents.Tests
{
    internal class ShopDbContext
    {
        internal object Database;

        public ShopDbContext(object options)
        {
            Options = options;
        }

        public object Products { get; internal set; }
        public object Options { get; }
    }
}