using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class CsvReaderExtensions
    {
        public static string ToTrimedValue(this List<char> values)
        {
            var stringValue = new string(values.ToArray());
            return stringValue.TrimEnd(new char[] {'"'});
        }
    }

    public static class GeneralExtensions
    {
        public static bool In<T>(this T value, IEqualityComparer<T> comparer, params T[] list)
            => list?.Contains(value, comparer) ?? false;

        public static bool In<T>(this T value, params T[] list)
            => value.In(EqualityComparer<T>.Default, list);

        public static bool NotIn<T>(this T value, IEqualityComparer<T> comparer, params T[] list)
            => !value.In(comparer, list);

        public static bool NotIn<T>(this T value, params T[] list)
            => !value.In(list);
    }
}
