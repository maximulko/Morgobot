using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Morgobot.Test.Mocks
{
    public class MemoryCacheMock : IMemoryCache
    {
        private Dictionary<object, object> _memory = new Dictionary<object, object>();

        public ICacheEntry CreateEntry(object key)
        {
            return new MemoryCacheEntry(key, this);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void SetValue(object key, object value)
        {
            _memory[key] = value;
        }

        public bool TryGetValue(object key, out object value)
        {
            if (!_memory.ContainsKey(key))
            {
                value = null;
                return false;
            }

            value = _memory[key];
            return true;
        }
    }

    public class MemoryCacheEntry : ICacheEntry
    {
        private readonly MemoryCacheMock _cache;

        public MemoryCacheEntry(object key, MemoryCacheMock cache)
        {
            Key = key;
            _cache = cache;
        }

        public object Key { get; private set; }

        public object Value {
            get
            {
                return null;
            }
            set
            {
                _cache.SetValue(Key, value);
            }
        }
        public DateTimeOffset? AbsoluteExpiration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan? SlidingExpiration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<IChangeToken> ExpirationTokens => throw new NotImplementedException();

        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks => throw new NotImplementedException();

        public CacheItemPriority Priority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            
        }
    }

}
