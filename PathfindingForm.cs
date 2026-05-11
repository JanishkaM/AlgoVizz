using AlgoVizz.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoVizz
{
    public partial class PathfindingForm : Form
    {
        private const int GridSize = 20;

        private PathNode[,] grid = null!;
        private readonly Queue<PathNode> bfsQueue = new Queue<PathNode>();
        private readonly System.Windows.Forms.Timer bfsTimer;

        private NodeType currentDrawMode = NodeType.Wall;
        private PathNode? startNode;
        private PathNode? endNode;

        public PathfindingForm()
        {
            InitializeComponent();

            bfsTimer = new System.Windows.Forms.Timer();
            bfsTimer.Interval = 150;
            bfsTimer.Tick += BfsTimer_Tick;

            modeComboBox.SelectedIndex = 0;
            speedComboBox.SelectedIndex = 1;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grid = new PathNode[GridSize, GridSize];
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    grid[x, y] = new PathNode { X = x, Y = y };
                }
            }

            startNode = null;
            endNode = null;
            bfsQueue.Clear();
            bfsTimer.Stop();
            drawPanel.Invalidate();
            statusLabel.Text = "Mode: " + currentDrawMode;
        }

        private void DrawPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (grid is null)
            {
                return;
            }

            var graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            float cellWidth = (float)drawPanel.Width / GridSize;
            float cellHeight = (float)drawPanel.Height / GridSize;

            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    using var brush = new SolidBrush(GetNodeColor(grid[x, y].Type));
                    graphics.FillRectangle(brush, x * cellWidth, y * cellHeight, cellWidth - 1, cellHeight - 1);
                }
            }
        }

        private static Color GetNodeColor(NodeType type)
        {
            return type switch
            {
                NodeType.Wall => Color.Black,
                NodeType.Start => Color.LimeGreen,
                NodeType.End => Color.Red,
                NodeType.Visited => Color.LightBlue,
                NodeType.Path => Color.Gold,
                _ => Color.White
            };
        }

        private void DrawPanel_MouseClick(object? sender, MouseEventArgs e)
        {
            if (bfsTimer.Enabled)
            {
                return;
            }

            float cellWidth = (float)drawPanel.Width / GridSize;
            float cellHeight = (float)drawPanel.Height / GridSize;

            int gridX = (int)(e.X / cellWidth);
            int gridY = (int)(e.Y / cellHeight);

            if (gridX < 0 || gridX >= GridSize || gridY < 0 || gridY >= GridSize)
            {
                return;
            }

            var node = grid[gridX, gridY];

            if (currentDrawMode == NodeType.Start)
            {
                if (endNode == node) return;
                if (startNode != null) startNode.Type = NodeType.Empty;
                node.Type = NodeType.Start;
                startNode = node;
            }
            else if (currentDrawMode == NodeType.End)
            {
                if (startNode == node) return;
                if (endNode != null) endNode.Type = NodeType.Empty;
                node.Type = NodeType.End;
                endNode = node;
            }
            else if (currentDrawMode == NodeType.Empty)
            {
                if (startNode == node) startNode = null;
                if (endNode == node) endNode = null;
                node.Type = NodeType.Empty;
            }
            else
            {
                if (startNode == node || endNode == node) return;
                node.Type = NodeType.Wall;
            }

            node.Parent = null;
            drawPanel.Invalidate();
        }

        private void StartButton_Click(object? sender, EventArgs e)
        {
            if (startNode == null || endNode == null)
            {
                MessageBox.Show("Place both Start and End nodes before running BFS.", "Missing Nodes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetSearchState();
            bfsQueue.Clear();
            bfsQueue.Enqueue(startNode);
            bfsTimer.Start();
            statusLabel.Text = "Searching...";
        }

        private void ResetSearchState()
        {
            for (int x = 0; x < GridSize; x++)
            {
                for (int y = 0; y < GridSize; y++)
                {
                    var node = grid[x, y];
                    node.Parent = null;

                    if (node.Type == NodeType.Visited || node.Type == NodeType.Path)
                    {
                        node.Type = NodeType.Empty;
                    }
                }
            }

            if (startNode != null) startNode.Type = NodeType.Start;
            if (endNode != null) endNode.Type = NodeType.End;

            drawPanel.Invalidate();
        }

        private void BfsTimer_Tick(object? sender, EventArgs e)
        {
            if (bfsQueue.Count == 0)
            {
                bfsTimer.Stop();
                statusLabel.Text = "No path found.";
                drawPanel.Invalidate();
                return;
            }

            var current = bfsQueue.Dequeue();

            if (current == endNode)
            {
                bfsTimer.Stop();
                TraceFinalPath(current);
                statusLabel.Text = "Path found.";
                return;
            }

            ExploreNeighbor(current.X + 1, current.Y, current);
            ExploreNeighbor(current.X - 1, current.Y, current);
            ExploreNeighbor(current.X, current.Y + 1, current);
            ExploreNeighbor(current.X, current.Y - 1, current);

            drawPanel.Invalidate();
        }

        private void ExploreNeighbor(int x, int y, PathNode parent)
        {
            if (x < 0 || y < 0 || x >= GridSize || y >= GridSize) return;

            var neighbor = grid[x, y];

            if (neighbor.Type == NodeType.Wall) return;
            if (neighbor == startNode) return;
            if (neighbor.Parent != null || neighbor.Type == NodeType.Visited || neighbor.Type == NodeType.Path) return;

            neighbor.Parent = parent;

            if (neighbor != endNode)
            {
                neighbor.Type = NodeType.Visited;
            }

            bfsQueue.Enqueue(neighbor);
        }

        private void TraceFinalPath(PathNode end)
        {
            var current = end.Parent;

            while (current != null && current != startNode)
            {
                current.Type = NodeType.Path;
                current = current.Parent;
            }

            drawPanel.Invalidate();
        }

        private void ClearPathButton_Click(object? sender, EventArgs e)
        {
            bfsTimer.Stop();
            ResetSearchState();
            bfsQueue.Clear();
            statusLabel.Text = "Path cleared.";
        }

        private void ResetGridButton_Click(object? sender, EventArgs e)
        {
            InitializeGrid();
            statusLabel.Text = "Grid reset.";
        }

        private void ModeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentDrawMode = modeComboBox.SelectedItem?.ToString() switch
            {
                "Start" => NodeType.Start,
                "End" => NodeType.End,
                "Erase" => NodeType.Empty,
                _ => NodeType.Wall
            };

            statusLabel.Text = "Mode: " + currentDrawMode;
        }

        private void SpeedComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bfsTimer.Interval = speedComboBox.SelectedItem?.ToString() switch
            {
                "Slow" => 350,
                "Fast" => 50,
                _ => 150
            };
        }
    }
}
