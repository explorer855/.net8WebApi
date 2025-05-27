namespace WebApi.Examples
{
    public class SingletonCosmosClient
    {
        private SingletonCosmosClient() { }
        private static SingletonCosmosClient _instance;
        private static readonly object lockRoot = new object();

        public static SingletonCosmosClient Instance
        {
            get {
                lock (lockRoot)
                {
                    if (_instance == null)
                        _instance = new SingletonCosmosClient();
                }

                return _instance;
            }
            
        }

        public void Print(string doc)
        {
            Console.WriteLine($"Printing document: {doc}");
        }
    }


    public class SingletonCosmosLazyClient
    {
        private SingletonCosmosLazyClient() { }
        private static readonly Lazy<SingletonCosmosLazyClient> _client = new(() => new SingletonCosmosLazyClient());

        public static SingletonCosmosLazyClient Instance => _client.Value;
    }
}
