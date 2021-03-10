using ServiceStack.Redis;
using System;

namespace ImplementationRedisKeyValue
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
             Forma mais simples e objetiva de se trabalhar com Redis
             
             */

            var key1 = Guid.NewGuid();
            var key2 = Guid.NewGuid();
            var key3 = Guid.NewGuid();

            var client1 = new Client(key1) { Name = "PauloPitte", Doc = "1234567890" };
            var client2 = new Client(key2) { Name = "JosePitte", Doc = "1234567890" };
            var client3 = new Client(key2) { Name = "BenPitte", Doc = "879546213" };

            var host = "localhost:6379";
            using (var redisClient = new RedisClient(host))
            {
                //Insert em base Redis com tempo de expiração decremental
                redisClient.Set<Client>(key1.ToString(), client1, 
                    new TimeSpan(hours: 0, minutes: 0, seconds: 10));

                redisClient.Set<Client>(key2.ToString(), client2, 
                    new TimeSpan(hours: 0, minutes: 0, seconds: 15));

                redisClient.Set<Client>(key3.ToString(), client3, 
                    new TimeSpan(hours: 0, minutes: 0, seconds: 20));

                // Consulta
                var clientX = redisClient.Get<Client>(client1.Key.ToString());


            }
        }
    }
}
