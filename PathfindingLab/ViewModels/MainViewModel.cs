using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using PathfindingLab.Algorithms;

namespace PathfindingLab.ViewModels;

public sealed class GridCell(CellPoint point) : ObservableObject
{
    private IBrush _fill = Brushes.White;
    public CellPoint Point { get; } = point;
    public string Label { get; set; } = "";
    public IBrush Fill { get => _fill; set => SetProperty(ref _fill, value); }
    public bool IsWall { get; set; }
}

public partial class MainViewModel : ViewModelBase
{
    public const int Width = 20;
    public const int Height = 12;
    private static readonly CellPoint Start = new(1, 5);
    private static readonly CellPoint Goal = new(18, 5);
    public string[] Algorithms { get; } = ["BFS", "DFS", "Dijkstra", "A*"];
    public ObservableCollection<GridCell> Cells { get; } = [];
    [ObservableProperty] private string _algorithm = "A*";
    [ObservableProperty] private string _status = "Clique nas células para alternar obstáculos e execute uma busca.";

    public MainViewModel()
    {
        for (var y = 0; y < Height; y++)
        for (var x = 0; x < Width; x++)
        {
            var cell = new GridCell(new(x, y));
            Cells.Add(cell);
            Paint(cell);
        }
    }

    public void ToggleWall(GridCell cell)
    {
        if (cell.Point == Start || cell.Point == Goal) return;
        cell.IsWall = !cell.IsWall;
        Paint(cell);
    }

    [RelayCommand]
    private async Task AnimatePath()
    {
        foreach (var cell in Cells.Where(c => !c.IsWall)) Paint(cell);
        var path = PathfindingEngine.FindPath(Width, Height, Start, Goal,
            Cells.Where(c => c.IsWall).Select(c => c.Point).ToHashSet(), Algorithm);
        if (path.Count == 0) { Status = "Nenhum caminho encontrado."; return; }
        Status = $"{Algorithm}: {path.Count - 1} passos. Animação em andamento…";
        foreach (var point in path.Skip(1).SkipLast(1))
        {
            var cell = Cells[point.Y * Width + point.X];
            cell.Fill = Brush.Parse("#6EE7B7");
            await Task.Delay(35);
        }
        Status = $"{Algorithm}: caminho com {path.Count - 1} passos.";
    }

    [RelayCommand]
    private void ClearWalls()
    {
        foreach (var cell in Cells) { cell.IsWall = false; Paint(cell); }
        Status = "Grade limpa.";
    }

    private static void Paint(GridCell cell)
    {
        cell.Fill = cell.Point == Start ? Brush.Parse("#2563EB")
            : cell.Point == Goal ? Brush.Parse("#DC2626")
            : cell.IsWall ? Brush.Parse("#334155") : Brush.Parse("#F8FAFC");
        cell.Label = cell.Point == Start ? "S" : cell.Point == Goal ? "G" : "";
    }
}
