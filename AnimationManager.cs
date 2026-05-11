using AlgoVizz.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoVizz
{
    public class AnimationManager
    {
        private Queue<Action> animationQueue = new Queue<Action>();
        private System.Windows.Forms.Timer animationTimer;
        private Panel panel;
        private int speed;
        private Action? onComplete;

        public AnimationManager(Panel panel, int speed)
        {
            this.panel = panel;
            this.speed = speed;

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = speed;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        public void QueueAction(Action action)
        {
            animationQueue.Enqueue(action);
        }

        public void StartAnimation(Action? onAnimationComplete = null)
        {
            onComplete = onAnimationComplete;
            if (animationQueue.Count > 0)
            {
                animationTimer.Start();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animationQueue.Count > 0)
            {
                Action action = animationQueue.Dequeue();
                action?.Invoke();
                panel.Invalidate(); // Redraw the panel
            }
            else
            {
                animationTimer.Stop();
                onComplete?.Invoke();
            }
        }

        public void ClearQueue()
        {
            animationQueue.Clear();
        }

        public void Dispose()
        {
            animationTimer?.Dispose();
        }
    }
}