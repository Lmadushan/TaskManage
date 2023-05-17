namespace TaskManage.Common
{
    public class DataMapper
    {
        public static List<TFirst> MapChild<TFirst, TSecond, TKey>(List<TFirst> parent, List<TSecond> child, Func<TFirst, TKey> firstKey, Func<TSecond, TKey> secondKey, Action<TFirst, IEnumerable<TSecond>> addChildren)
        {
            Dictionary<TKey, IEnumerable<TSecond>> dictionary = child.GroupBy(secondKey).ToDictionary((IGrouping<TKey, TSecond> g) => g.Key, (IGrouping<TKey, TSecond> g) => g.AsEnumerable());
            foreach (TFirst item in parent)
            {
                if (dictionary.TryGetValue(firstKey(item), out var value))
                {
                    addChildren(item, value);
                }
            }

            return parent;
        }
    }
}