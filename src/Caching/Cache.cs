using System;
using System.Runtime.Caching;

namespace Hefferon.Core.Caching
{
    /// <summary>
    /// Implements <see cref="ICache"/> interface and provides cache functionality using the <see cref="MemoryCache"/>.
    /// </summary>
    public class Cache : ICache
    {
        #region Fields

        private ObjectCache ObjectCache { get { return MemoryCache.Default; } }

        #endregion // Fields

        #region Methods

        #region Helpers

        /// <summary>
        /// Adds <pararef name="data"/> object in to the cache under the given <pararef name="key"/> with the given <pararef name="expiration"/> date.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <param name="data">Object to be cached.</param>
        /// <param name="expiration">Expiration time of the cached object.</param>
        private void Add(string key, object data, DateTimeOffset expiration)
        {
            Add(new CacheItem(key, data), new CacheItemPolicy { AbsoluteExpiration = expiration });
        }

        /// <summary>
        /// Adds <pararef name="cacheItem"/> with the <pararef name="cacheItemPolicy"/> in to the cache.
        /// </summary>
        /// <param name="cacheItem">Cache item to be cached.</param>
        /// <param name="cacheItemPolicy">Cache policy of the given <pararef name="cacheItem"/>.</param>
        private void Add(CacheItem cacheItem, CacheItemPolicy cacheItemPolicy)
        {
            ObjectCache.Add(cacheItem, cacheItemPolicy);
        }

        #endregion // Helpers

        #endregion // Methods

        #region Interface Implementations

        #region ICache Members

        /// <summary>
        /// Retrieves cached object specified by the <pararef name="key"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <returns>Cached object.</returns>
        public object Get(string key)
        {
            return ObjectCache[key];
        }

        /// <summary>
        /// Determines if there is an object with the specified <pararef name="key"/> in the cache.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <returns><c>true</c>, if the object with given <pararef name="key"/> is currently cached; otherwise, <c>false</c>.</returns>
        public bool IsCached(string key)
        {
            return (ObjectCache[key] != null);
        }

        /// <summary>
        /// Adds permanently <pararef name="data"/> object in to the cache under the given <pararef name="key"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <param name="data">Object to be cached.</param>
        public void Add(string key, object data)
        {
            Add(key, data, DateTime.MaxValue);
        }

        /// <summary>
        /// Adds <pararef name="data"/> object in to the cache under the given <pararef name="key"/> for number of minutes specified by <pararef name="cacheTime"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <param name="data">Object to be cached.</param>
        /// <param name="cacheTime">Number of minutes, given object will be cached.</param>
        public void Add(string key, object data, int cacheTime)
        {
            Add(key, data, DateTime.Now + TimeSpan.FromMinutes(cacheTime));
        }

        /// <summary>
        /// Removes object with <pararef name="key"/> from the cache.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        public void Remove(string key)
        {
            ObjectCache.Remove(key);
        }

        public string NullAsString()
        {
            return "<null>";
        }

        #endregion // ICache Members

        #endregion // Interface Implementations
    }
}