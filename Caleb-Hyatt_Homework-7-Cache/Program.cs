using Caleb_Hyatt_Homework_7_Cache;

var cache = new Cache(2);

Console.WriteLine("--- LRU ---\n");

/**
 * A real-world example of an LRU cache is the cache used by a web browser to store recently visited web pages. When you visit a website, your browser caches a copy of the page and its resources, such as images and scripts. When you return to the same website, the web browser can load the page from the cache rather than downloading it from the internet, which can be much faster.
 * However, because the cache has a limited capacity, it cannot store an infinite number of web pages. When the cache is full, the web browser must remove some of the previously cached web pages to make room for new ones. In this case, the web browser determines which web pages to evict using an LRU cache algorithm. Web pages that have not been accessed in a long time are removed first, while pages that have been accessed recently are kept in the cache.
 */

var lru1 = cache.GetLRU("1");
Console.WriteLine(lru1);
var lru2 = cache.GetLRU("2");
Console.WriteLine(lru2);
var lru3 = cache.GetLRU("3");
Console.WriteLine(lru3);
var lru4 = cache.GetLRU("2");
Console.WriteLine(lru4);
var lru5 = cache.GetLRU("4");
Console.WriteLine(lru5);

Console.WriteLine("\n--- LFU ---");
cache.ClearCache();

/**
 * Font caching in web browsers is an example of an LFU cache in action. When a web page is loaded, the browser may need to download fonts that the page requires. The web browser can cache downloaded fonts in memory or on disk to speed up subsequent page loads.
 * An LFU cache can be used to prioritize the caching of the most frequently used fonts while evicting fonts that are used less frequently to make room for new fonts. When cached fonts are used, their frequency count is incremented, and when the cache is full, the font with the lowest frequency count is evicted.
 * Font caching with an LFU cache can improve page load times and reduce the number of font downloads required because frequently used fonts can be served from the cache rather than being downloaded each time they are needed. This can enhance the overall user experience while also reducing the load on web servers.
 */

var lfu1 = cache.GetLFU("1");
Console.WriteLine(lfu1);
var lfu2 = cache.GetLFU("1");
Console.WriteLine(lfu2);
var lfu3 = cache.GetLFU("2");
Console.WriteLine(lfu3);
var lfu4 = cache.GetLFU("2");
Console.WriteLine(lfu4);
var lfu5 = cache.GetLFU("2");
Console.WriteLine(lfu5);
var lfu6 = cache.GetLFU("3");
Console.WriteLine(lfu6);
var lfu7 = cache.GetLFU("4");
Console.WriteLine(lfu7);