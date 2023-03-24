using System.Collections.Generic;
using System.Linq;

namespace Assets.Scrypts.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Mix<T>(this T[] values)
        {
            var random = new System.Random();
            for (var i = values.Length - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                var temp = values[j];
                values[j] = values[i];
                values[i] = temp;
            }
            return values;
        }

        public static List<T> Mix<T>(this IEnumerable<T> values)
            => values.ToArray().Mix().ToList();
    }
}