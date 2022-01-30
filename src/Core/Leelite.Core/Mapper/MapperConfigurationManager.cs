namespace Leelite.Core.Mapper
{
    public static class MapperConfigurationManager
    {
        private static MapperConfigurationContext _context;

        public static MapperConfigurationContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new MapperConfigurationContext();
                }
                return _context;
            }
        }
    }
}
