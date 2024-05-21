using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Eremex.AvaloniaUI.Controls.Bars;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace DemoCenter.ViewModels;

public partial class MvvmToolbarManagerViewModel : PageViewModelBase
{
    [ObservableProperty] private ObservableCollection<MvvmToolbarViewModel> topToolbars;
    [ObservableProperty] private ObservableCollection<MvvmToolbarViewModel> bottomToolbars;
    

    public MvvmToolbarManagerViewModel()
    {
        topToolbars = new ObservableCollection<MvvmToolbarViewModel>();
        bottomToolbars = new ObservableCollection<MvvmToolbarViewModel>();
    }
}

public partial class MvvmToolbarViewModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<MvvmToolbarItemViewModel> items;
    [ObservableProperty] private ToolbarDisplayMode displayMode;
    [ObservableProperty] private bool stretchToolbar;
    public MvvmToolbarViewModel()
    {
        items = new ObservableCollection<MvvmToolbarItemViewModel>();
    }
}

public partial class MvvmToolbarItemViewModel : ObservableObject
{
    [ObservableProperty] private ICommand command;
    [ObservableProperty] private object commandParameter;
    [ObservableProperty] private string header;
    [ObservableProperty] private IImage glyph;
    [ObservableProperty] private ToolbarItemDisplayMode displayMode;
    [ObservableProperty] private bool showSeparator;
}

public partial class MvvmToolbarButtonItemViewModel : MvvmToolbarItemViewModel
{
    
}

public partial class MvvmToolbarCheckItemViewModel : MvvmToolbarItemViewModel
{
    [ObservableProperty] private bool isChecked;
}

public partial class MvvmToolbarMenuItemViewModel : MvvmToolbarItemViewModel
{
    [ObservableProperty] private ObservableCollection<MvvmToolbarItemViewModel> items;

    public MvvmToolbarMenuItemViewModel()
    {
        items = new ObservableCollection<MvvmToolbarItemViewModel>();
    }
}

public partial class MvvmToolbarCheckGroupViewModel : MvvmToolbarItemViewModel
{
    [ObservableProperty] private ObservableCollection<MvvmToolbarItemViewModel> items;
    [ObservableProperty] private ToolbarItemCheckType type;

    public MvvmToolbarCheckGroupViewModel()
    {
        items = new ObservableCollection<MvvmToolbarItemViewModel>();
    }
}

public partial class MvvmToolbarTextItemViewModel : MvvmToolbarItemViewModel
{
    [ObservableProperty] private bool showBorder;
}

public class MvvmToolbarItemCommand : ICommand
{
    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        var msg = MessageBoxManager.GetMessageBoxStandard( "Command", Convert.ToString(parameter) + " Command Executed!", ButtonEnum.Ok);
        msg.ShowAsync();
    }

    #pragma warning disable CS0067
    public event EventHandler CanExecuteChanged;
    #pragma warning restore CS0067
}

