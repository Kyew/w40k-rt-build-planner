using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W40KRogueTrader_BuildPlanner.Utils.Extensions
{
    public static class ObservableCollectionExt
    {
        public static void CopyFrom<T>(this ObservableCollection<T> collection, List<T> list)
        {
            collection.Clear();
            foreach (T item in list)
            {
                collection.Add(item);
            }
        }
    }
}
