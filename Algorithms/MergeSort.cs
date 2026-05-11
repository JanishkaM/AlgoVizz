using AlgoVizz.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoVizz.Algorithms
{
    public class MergeSort
    {
        public static int Sort(List<Element> elements, AnimationManager animationManager, int tk)
        {
            int ICount = 0;
            ICount = MergeSortHelper(elements, 0, elements.Count - 1, animationManager, tk, ref ICount);
            return ICount;
        }

        private static int MergeSortHelper(List<Element> elements, int left, int right, 
            AnimationManager animationManager, int tk, ref int ICount)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSortHelper(elements, left, mid, animationManager, tk, ref ICount);
                MergeSortHelper(elements, mid + 1, right, animationManager, tk, ref ICount);
                Merge(elements, left, mid, right, animationManager, tk, ref ICount);
            }
            return ICount;
        }

        private static void Merge(List<Element> elements, int left, int mid, int right, 
            AnimationManager animationManager, int tk, ref int ICount)
        {
            List<Element> temp = new List<Element>();
            
            int i = left;
            int j = mid + 1;
            
            while (i <= mid && j <= right)
            {
                if (elements[i].Value <= elements[j].Value)
                {
                    temp.Add(elements[i].Clone());
                    i++;
                }
                else
                {
                    temp.Add(elements[j].Clone());
                    j++;
                }
                ICount++;
            }
            
            while (i <= mid)
            {
                temp.Add(elements[i].Clone());
                i++;
                ICount++;
            }
            
            while (j <= right)
            {
                temp.Add(elements[j].Clone());
                j++;
                ICount++;
            }
            
            for (int k = 0; k < temp.Count; k++)
            {
                int index = left + k;
                Element tempElement = temp[k];
                
                animationManager.QueueAction(() =>
                {
                    elements[index] = tempElement;
                    elements[index].SelectedOne(null, tk);
                });
            }
        }
    }
}