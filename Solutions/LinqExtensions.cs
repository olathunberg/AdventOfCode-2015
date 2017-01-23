using System.Collections.Generic;

namespace Solutions
{

    public static class LinqExtensions
    {
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
