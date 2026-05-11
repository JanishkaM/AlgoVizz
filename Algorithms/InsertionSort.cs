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
            int ICount = 0;
            int n = elements.Count;

            for (int i = 1; i < n; ++i)
            {
                int currentIndex = i;
                
                // Queue action to highlight current element
                animationManager.QueueAction(() =>
                {
                    elements[currentIndex].SelectedOne(null, tk);
                });

                int key = elements[i].Value;
                int j = i - 1;

                while (j >= 0 && elements[j].Value > key)
                {
                    int first = j;
                    int second = j + 1;

                    // Queue action to show selected elements
                    animationManager.QueueAction(() =>
                    {
                        elements[first].Selected(null, tk);
                        elements[second].Selected(null, tk);
                    });

                    // Queue action to perform swap
                    animationManager.QueueAction(() =>
                    {
                        elements[first].End = new Point(elements[first].End.X, elements[second].End.Y);
                        elements[second].End = new Point(elements[second].End.X, 
                            elements[first].End.Y - (elements[second].End.Y - elements[first].End.Y));
                        
                        var tempValue = elements[first].Value;
                        elements[first].Value = elements[second].Value;
                        elements[second].Value = tempValue;
                    });

                    j = j - 1;
                    ICount++;
                }

                elements[j + 1].Value = key;
                ICount++;
            }

            return ICount;
        }
    }
}