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
    public class InsertionSort
    {
        public static int Sort(List<Element> elements, AnimationManager animationManager, int tk)
        {
            int iCount = 0;
            int n = elements.Count;
            var values = elements.Select(e => e.Value).ToArray();
            var swapOperations = new List<(int Left, int Right)>();

            foreach (var element in elements)
            {
                element.VisualState = ElementVisualState.Normal;
            }

            for (int i = 1; i < n; i++)
            {
                int k = i;
                while (k > 0 && values[k - 1] > values[k])
                {
                    (values[k - 1], values[k]) = (values[k], values[k - 1]);
                    swapOperations.Add((k - 1, k));
                    k--;
                    iCount++;
                }

                iCount++;
            }

            foreach (var (left, right) in swapOperations)
            {
                animationManager.QueueAction(() =>
                {
                    elements[left].VisualState = ElementVisualState.Comparing;
                    elements[right].VisualState = ElementVisualState.Current;
                });

                animationManager.QueueAction(() =>
                {
                    int leftY = elements[left].End.Y;
                    int rightY = elements[right].End.Y;

                    elements[left].End = new Point(elements[left].End.X, rightY);
                    elements[right].End = new Point(elements[right].End.X, leftY);

                    (elements[left].Value, elements[right].Value) = (elements[right].Value, elements[left].Value);
                });

                animationManager.QueueAction(() =>
                {
                    elements[left].VisualState = ElementVisualState.Normal;
                    elements[right].VisualState = ElementVisualState.Normal;
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
    }
}