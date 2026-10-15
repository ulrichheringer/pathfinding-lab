using PathfindingLab.Algorithms;

var walls = new HashSet<CellPoint> { new(2, 1), new(2, 2) };
foreach (var algorithm in new[] { "BFS", "DFS", "Dijkstra", "A*" })
{
    var path = PathfindingEngine.FindPath(5, 4, new(0, 0), new(4, 3), walls, algorithm);
    if (path.Count == 0 || path[0] != new CellPoint(0, 0) || path[^1] != new CellPoint(4, 3) || path.Any(walls.Contains))
        throw new Exception($"{algorithm} did not return a valid route.");
}
if (PathfindingEngine.FindPath(2, 2, new(0, 0), new(1, 1), new HashSet<CellPoint> { new(1, 0), new(0, 1) }, "BFS").Count != 0)
    throw new Exception("A blocked grid should have no route.");
Console.WriteLine("Pathfinding checks passed.");
