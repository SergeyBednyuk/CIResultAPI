using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.SupportClasses.Extensions
{
    public static class ResizeListExtension
    {
        public static void ResizeList<T>(this IList<T> list, int size)
        {
            if (list == null)
                throw new ArgumentException(nameof(list));

            if (size < 0)
                throw new ArgumentException(nameof(size));

            while (list.Count > size)
                list.RemoveAt(list.Count - 1);

        }
    }
}
