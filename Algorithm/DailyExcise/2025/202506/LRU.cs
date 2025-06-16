using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class LRUCache<K,V>
    {
        private readonly int capacity;
        private Dictionary<K, LinkedListNode<(K key, V value)>> cacheMap;
        private LinkedList<(K key, V value)> lruList;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            lruList = new LinkedList<(K key, V value)>();
            cacheMap = new Dictionary<K, LinkedListNode<(K key, V value)>>();
        }

        public V Get(K key)
        {
            if(cacheMap.TryGetValue(key, out var node))
            {
                lruList.Remove(node);
                lruList.AddFirst(node);
                return node.Value.value;
            }
            throw new KeyNotFoundException("key does no exist  in the cache");
        }

        public void Put(K key, V value)
        {
            if(cacheMap.TryGetValue(key, out var node))
            {
                lruList.Remove(node);

            }else if(lruList.Count>=capacity)
            {
                var last = lruList.Last;
                lruList.Remove(last);
                cacheMap.Remove(last.Value.key);
            }
            var newnode = lruList.AddFirst((key, value));
            cacheMap[key] = newnode;
        }
    }
    public class LRU
    {
        public void Test()
        {
            var cache = new LRUCache<int, string>(3);
            cache.Put(1, "A");
            cache.Put(2, "B");
            cache.Put(3, "C");
            Console.WriteLine(cache.Get(1));//A
            cache.Put(4, "D");//evicted key  2
            cache.Put(5, "E");//evicted key 3

        }
    }
}
