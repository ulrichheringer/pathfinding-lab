
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using PathfindingLab.ViewModels;

namespace PathfindingLab.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void CellPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Control { DataContext: GridCell cell } && DataContext is MainViewModel viewModel)
            viewModel.ToggleWall(cell);
    }
}
