namespace PathfindingLab.Algorithms;

public readonly record struct CellPoint(int X, int Y);

public static class PathfindingEngine
{
    private static readonly CellPoint[] Neighbors = [new(0, -1), new(1, 0), new(0, 1), new(-1, 0)];

    public static IReadOnlyList<CellPoint> FindPath(
        int width, int height, CellPoint start, CellPoint goal,
        IReadOnlySet<CellPoint> walls, string algorithm)
    {
        if (width <= 0 || height <= 0 || !Inside(start) || !Inside(goal) || walls.Contains(start) || walls.Contains(goal))
            return [];

        bool Inside(CellPoint p) => p.X >= 0 && p.X < width && p.Y >= 0 && p.Y < height;
        var frontier = new PriorityQueue<CellPoint, int>();
        var cameFrom = new Dictionary<CellPoint, CellPoint>();
        var cost = new Dictionary<CellPoint, int> { [start] = 0 };
        var visited = new HashSet<CellPoint> { start };
        frontier.Enqueue(start, 0);

        while (frontier.TryDequeue(out var current, out _))
        {
            if (current == goal) return Reconstruct(cameFrom, goal);
            foreach (var offset in Neighbors)
            {
                var next = new CellPoint(current.X + offset.X, current.Y + offset.Y);
                if (!Inside(next) || walls.Contains(next)) continue;

                var newCost = cost[current] + 1;
                if (algorithm == "DFS")
                {
                    if (!visited.Add(next)) continue;
                    cameFrom[next] = current;
                    cost[next] = newCost;
                    frontier.Enqueue(next, -newCost);
                }
                else if (!cost.TryGetValue(next, out var oldCost) || newCost < oldCost)
                {
                    cost[next] = newCost;
                    cameFrom[next] = current;
                    var priority = algorithm == "A*" ? newCost + Manhattan(next, goal) : newCost;
                    frontier.Enqueue(next, priority);
                }
            }
        }

        return [];
    }

    private static int Manhattan(CellPoint a, CellPoint b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);

    private static IReadOnlyList<CellPoint> Reconstruct(Dictionary<CellPoint, CellPoint> cameFrom, CellPoint goal)
    {
        var path = new List<CellPoint> { goal };
        while (cameFrom.TryGetValue(path[^1], out var previous)) path.Add(previous);
        path.Reverse();
        return path;
    }
}
