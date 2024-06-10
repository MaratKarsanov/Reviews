using Newtonsoft.Json;
using StackExchange.Redis;

namespace Review.Domain.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase database;

        public CacheService()
        {
            ConfigureRedis();
        }

        private void ConfigureRedis()
        {
            database = ConnectionHelper.Connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = database.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = database.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }

        public bool RemoveData(string key)
        {
            return database.KeyDelete(key);
        }
    }
}
