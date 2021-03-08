namespace Hefferon.Core.Caching
{
    /// <summary>
    /// Defines functionality of the cache.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Retrieves cached object specified by the <pararef name="key"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <returns>Cached object.</returns>
        object Get(string key);

        /// <summary>
        /// Determines if there is an object with the specified <pararef name="key"/> in the cache.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <returns><c>true</c>, if the object with given <pararef name="key"/> is currently cached; otherwise, <c>false</c>.</returns>
        bool IsCached(string key);

        /// <summary>
        /// Adds permanently <pararef name="data"/> object in to the cache under the given <pararef name="key"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <param name="data">Object to be cached.</param>
        void Add(string key, object data);

        /// <summary>
        /// Adds <pararef name="data"/> object in to the cache under the given <pararef name="key"/> for number of minutes specified by <pararef name="cacheTime"/>.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        /// <param name="data">Object to be cached.</param>
        /// <param name="cacheTime">Number of minutes, given object will be cached.</param>
        void Add(string key, object data, int cacheTime);

        /// <summary>
        /// Removes object with <pararef name="key"/> from the cache.
        /// </summary>
        /// <param name="key">Cached object key.</param>
        void Remove(string key);

        string NullAsString();
    }
}