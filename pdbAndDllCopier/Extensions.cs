using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace pdbAndDllCopier
{
    static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static void AddRange<T>(this BindingList<T> list, IEnumerable<T> stuffToAdd)
        {
            if (stuffToAdd.Count() > 1)
            {
                list.RaiseListChangedEvents = false;
                foreach (var binFolder in stuffToAdd.Take(stuffToAdd.Count() - 2))
                {
                    list.Add(binFolder);
                }
                list.RaiseListChangedEvents = true;
                list.Add(stuffToAdd.Last());
            }
        }

        public static bool Like(this string toSearch, string toFind)
            =>
                new Regex(
                    @"\A" +
                    new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch)
                        .Replace('_', '.')
                        .Replace("%", ".*") + @"\z", RegexOptions.Singleline|RegexOptions.IgnoreCase).IsMatch(toSearch);
    }

}