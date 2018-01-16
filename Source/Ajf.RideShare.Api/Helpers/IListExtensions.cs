using System.Collections.Generic;
using System.Linq;

namespace Ajf.RideShare.Api.Helpers
{
    public static class IListExtensions
    {
        public static void RemoveRange<T>(this IList<T> source, IEnumerable<T> rangeToRemove)
        {
            if (rangeToRemove == null | !rangeToRemove.Any())
                return;

            foreach (T item in rangeToRemove)
            {
                source.Remove(item);
            }


        }
    }
}