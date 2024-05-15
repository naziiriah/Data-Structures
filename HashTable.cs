using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning;


class HashTable<TKey, TValue>
{
    private const int InitialCapacity = 10;
    private List<KeyValuePair<TKey, TValue>>[] buckets;

    public HashTable()
    {
        buckets = new List<KeyValuePair<TKey, TValue>>[InitialCapacity];
    }

    private int GetBucketIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode) % buckets.Length;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] == null)
            buckets[index] = new List<KeyValuePair<TKey, TValue>>();

        buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = GetBucketIndex(key);
        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
        }

        value = default(TValue);
        return false;
    }
}

class Prram
{
    static void Main(string[] args)
    {
        HashTable<string, int> scores = new HashTable<string, int>();
        scores.Add("Alice", 90);
        scores.Add("Bob", 85);
        scores.Add("Charlie", 78);

        if (scores.TryGetValue("Bob", out int bobScore))
            Console.WriteLine($"Bob's score: {bobScore}");
        else
            Console.WriteLine("Bob not found in the hash table.");
    }

}