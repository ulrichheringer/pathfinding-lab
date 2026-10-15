# pathfinding-lab

A visual playground for BFS, DFS, Dijkstra, and A* on a grid. Add walls and watch each algorithm explore the board and find a route.

## Run

Requires the .NET 10 SDK. Browser builds also need the WebAssembly workload: `dotnet workload install wasm-tools`.

### Desktop

~~~sh
dotnet run --project PathfindingLab.Desktop/PathfindingLab.Desktop.csproj
~~~

### Browser

~~~sh
dotnet run --project PathfindingLab.Browser/PathfindingLab.Browser.csproj
~~~

## Example

Choose A*, draw a few walls on the grid, and click **Find path**.
