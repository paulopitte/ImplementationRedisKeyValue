using System;

namespace ImplementationRedisKeyValue
{
    class Client
    {
        public Guid Key { get; private set; }
        public string Doc { get; set; }
        public string Name { get; set; }

        public Client(Guid key) =>
            Key = key;


    }
}
