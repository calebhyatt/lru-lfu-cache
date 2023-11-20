namespace Caleb_Hyatt_Homework_7_Cache
{
    public class CacheData
    {
        public string data { get; set; }
        public int order { get; set; }
        public DateTime lastUsed { get; set; } = DateTime.Now;
        public int accessCount { get; set; } = 0;
    }

    internal class Cache
    {
        public Dictionary<string, CacheData> data;
        public int size { get; set; }
        public int order = 0;

        public Cache(int size)
        {
            this.size = size;
            this.data = new Dictionary<string, CacheData>();
        }

        public void ClearCache()
        {
            foreach (string key in this.data.Keys)
            {
                this.data.Remove(key);
            }
        }

        /**
         * --- FIFO ---
         * This just returns the cache, ordered by order.
         */
        public string Get(string key)
        {
            // If cache hit
            if (this.data.ContainsKey(key))
            {
                // Say so and return the value (data)
                Console.WriteLine($"Cache hit for {key}");
                return this.data[key].data;
            }
            // If cache miss
            else
            {
                // Say so
                Console.WriteLine($"Cache miss for {key}");


                // songString is a proof of work. I changed it to be one line/variable
                // This portion was done in class
                var songString = string.Join("", key.Reverse().ToArray());

                if (this.data.Count >= this.size)
                {
                    // The OrderBy sort is changed to sort by the order property
                    var firstIn = this.data.OrderBy(x => x.Value.order).First().Key;
                    Console.WriteLine($"[FIFO] Evicting item with key {firstIn}");
                    this.data.Remove(firstIn);
                }

                // Changed the increment to be cleaner
                this.order++;
                this.data[key] = new CacheData() { data = songString, order = this.order };
                return songString;
            }
        }

        /**
         * --- LRU ---
         * Same appraoch as the Get method. The difference is we set the lastUsed property to the current time with DateTime.Now and it's sorted by lastUsed.
         */
        public string GetLRU(string key)
        {
            if (this.data.ContainsKey(key))
            {
                this.data[key].lastUsed = DateTime.Now;
                Console.WriteLine($"Cache hit for {key}");
                return this.data[key].data;
            }
            else
            {
                Console.WriteLine($"Cache miss for {key}");

                var songString = string.Join("", key.Reverse().ToArray());

                if (this.data.Count >= this.size)
                {
                    var leastRecent = this.data.OrderBy(x => x.Value.lastUsed).First().Key;
                    Console.WriteLine($"[LRU] Evicting item with key {leastRecent}");
                    this.data.Remove(leastRecent);
                }

                this.order++;
                this.data[key] = new CacheData() { data = songString, order = this.order };
                return songString;
            }
        }

        /**
         * --- LFU ---
         * Same appraoch as LRU except we increment accessCount by 1 instead of changing lastUsed and sort by that property.
         */
        public string GetLFU(string key)
        {
            if (this.data.ContainsKey(key))
            {
                this.data[key].accessCount++;
                Console.WriteLine($"Cache hit for {key}");
                return this.data[key].data;
            }
            else
            {
                Console.WriteLine($"Cache miss for {key}");

                var songString = string.Join("", key.Reverse().ToArray());

                if (this.data.Count >= this.size)
                {
                    var leastFrequent = this.data.OrderBy(x => x.Value.accessCount).First().Key;
                    Console.WriteLine($"[LFU] Evicting item with key {leastFrequent}");
                    this.data.Remove(leastFrequent);
                }

                this.order++;
                this.data[key] = new CacheData() { data = songString, order = this.order };
                return songString;
            }
        }
    }
}
