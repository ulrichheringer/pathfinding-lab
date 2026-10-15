# Pathfinding Lab

[![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/) [![.NET 10](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/) ![Avalonia UI](https://img.shields.io/badge/UI-Avalonia-8B5CF6?style=flat-square) [![MIT License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE) ![Windows target](https://img.shields.io/badge/Windows-target-0078D6?style=flat-square&logo=windows&logoColor=white) ![macOS target](https://img.shields.io/badge/macOS-target-000000?style=flat-square&logo=apple&logoColor=white) ![WebAssembly target](https://img.shields.io/badge/WebAssembly-target-654FF0?style=flat-square&logo=webassembly&logoColor=white)

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
