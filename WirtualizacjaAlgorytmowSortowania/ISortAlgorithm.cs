using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirtualizacjaAlgorytmowSortowania
{
    public interface ISortAlgorithm
    {
        void Sort(int[] arr, ref int comparisons, ref int[] selectedArr, Action AddHistorySnap, Action DrawHistory);
    }
}
