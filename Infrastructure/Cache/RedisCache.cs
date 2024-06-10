using Domain.Interface.Cache;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public class RedisCache : IRedisCache
    {
        private readonly IDatabase db;

        public RedisCache(IConnectionMultiplexer connection)
        {
            db = connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default(T);
        }

        public object RemoveData(string key)
        {
            bool isKeyExist = db.KeyExists(key);
            if (isKeyExist)
            {
                return db.KeyDelete(key);
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.UtcNow);
            var isSet = db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
