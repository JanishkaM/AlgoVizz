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
        private struct MergeWrite
        {
            public int Index;
            public int Value;
        }

        public static int Sort(List<Element> elements, AnimationManager animationManager, int tk)
        {
            int iCount = 0;
            var values = elements.Select(e => e.Value).ToArray();
            var writes = new List<MergeWrite>();

            foreach (var element in elements)
            {
                element.VisualState = ElementVisualState.Normal;
            }

            MergeSortHelper(values, 0, values.Length - 1, writes, ref iCount);

            foreach (var write in writes)
            {
                int index = write.Index;
                int targetValue = write.Value;

                animationManager.QueueAction(() =>
                {
                    elements[index].VisualState = ElementVisualState.Current;
                });

                animationManager.QueueAction(() =>
                {
                    int panelHeight = elements[index].Start.Y;
                    int targetY = panelHeight - targetValue;

                    elements[index].Value = targetValue;
                    elements[index].End = new Point(elements[index].End.X, targetY);
                });

                animationManager.QueueAction(() =>
                {
                    elements[index].VisualState = ElementVisualState.Normal;
                });
            }

            animationManager.QueueAction(() =>
            {
                foreach (var element in elements)
                {
                    element.VisualState = ElementVisualState.Sorted;
                }
            });

            return iCount;
        }

        private static void MergeSortHelper(int[] values, int left, int right, List<MergeWrite> writes, ref int iCount)
        {
            if (left >= right)
            {
                return;
            }

            int mid = left + (right - left) / 2;
            MergeSortHelper(values, left, mid, writes, ref iCount);
            MergeSortHelper(values, mid + 1, right, writes, ref iCount);
            Merge(values, left, mid, right, writes, ref iCount);
        }

        private static void Merge(int[] values, int left, int mid, int right, List<MergeWrite> writes, ref int iCount)
        {
            int[] leftPart = new int[mid - left + 1];
            int[] rightPart = new int[right - mid];

            Array.Copy(values, left, leftPart, 0, leftPart.Length);
            Array.Copy(values, mid + 1, rightPart, 0, rightPart.Length);

            int i = 0;
            int j = 0;
            int k = left;

            while (i < leftPart.Length && j < rightPart.Length)
            {
                iCount++;
                if (leftPart[i] <= rightPart[j])
                {
                    values[k] = leftPart[i];
                    writes.Add(new MergeWrite { Index = k, Value = leftPart[i] });
                    i++;
                }
                else
                {
                    values[k] = rightPart[j];
                    writes.Add(new MergeWrite { Index = k, Value = rightPart[j] });
                    j++;
                }
                k++;
            }

            while (i < leftPart.Length)
            {
                iCount++;
                values[k] = leftPart[i];
                writes.Add(new MergeWrite { Index = k, Value = leftPart[i] });
                i++;
                k++;
            }

            while (j < rightPart.Length)
            {
                iCount++;
                values[k] = rightPart[j];
                writes.Add(new MergeWrite { Index = k, Value = rightPart[j] });
                j++;
                k++;
            }
        }
    }
}