using SimpleInjector;


namespace Core
{
    public static class Bootstrapper
    {
        private static readonly Container _container;

        static Bootstrapper()
        {
            _container = new Container();
        }

        public static Container Container
        {
            get { return _container; }
        }
    }
}
