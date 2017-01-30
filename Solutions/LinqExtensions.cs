using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list)
        {
            return GetPermutations<T>(list, list.Count());
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static IEnumerable<T[]> Windowed<T>(this IEnumerable<T> list, int windowSize)
        {
            var arr = new T[windowSize];
            int r = windowSize - 1, i = 0;
            using (var e = list.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    arr[i] = e.Current;
                    i = (i + 1) % windowSize;
                    if (r == 0)
                    {
                        var arrR = new T[windowSize]; for (int j = 0; j < windowSize; j++) { arrR[j] = arr[(i + j) % windowSize]; }
                        yield return arrR;
                    }
                    else
                        r--;
                }
            }
        }
    }
}
