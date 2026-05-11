using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoVizz;

namespace AlgoVizz.Entity
{
    public enum ElementVisualState
    {
        Normal,
        Comparing,
        Current,
        Sorted
    }

    public class Element
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public int Value { get; set; }

        public ElementVisualState VisualState { get; set; } = ElementVisualState.Normal;

        public Element(Point start, Point end, int value)
        {
            Start = start;
            End = end;
            Value = value;
        }

        public Element Clone() => new Element(Start, End, Value) { VisualState = VisualState };

        public void Draw(Graphics? graphics, int tk)
        {
            if (graphics is null) return;

            Color color = VisualState switch
            {
                ElementVisualState.Comparing => Color.Green,
                ElementVisualState.Current => Color.Purple,
                ElementVisualState.Sorted => Color.Blue,
                _ => Color.Red
            };

            using var pen = new Pen(color, tk);
            graphics.DrawLine(pen, Start, End);
        }

        public void Eraser(Graphics? graphics, int tk)
        {
            if (graphics is null) return;
            using var pen = new Pen(Color.Black, tk);
            graphics.DrawLine(pen, Start, End);
        }

        public void Selected(Graphics? graphics, int tk)
        {
            if (graphics is null) return;
            using var pen = new Pen(Color.Green, tk);
            graphics.DrawLine(pen, Start, End);
        }

        public void SelectedOne(Graphics? graphics, int tk)
        {
            if (graphics is null) return;
            using var pen = new Pen(Color.Purple, tk);
            graphics.DrawLine(pen, Start, End);
        }
    }
}