namespace AlgoVizz.Entity
{
    public enum NodeType
    {
        Empty,
        Wall,
        Start,
        End,
        Visited,
        Path
    }

    public class PathNode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public NodeType Type { get; set; } = NodeType.Empty;
        public PathNode? Parent { get; set; }
    }
}
