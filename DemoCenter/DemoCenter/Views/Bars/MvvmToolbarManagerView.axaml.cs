using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using DemoCenter.ViewModels;
using DynamicData;
using Eremex.AvaloniaUI.Controls.Bars;
using Svg = Avalonia.Svg.Skia.Svg;

namespace DemoCenter.Views;

public partial class MvvmToolbarManagerView : UserControl
{
    public MvvmToolbarManagerView()
    {
        InitializeComponent();
        DataContext = GetViewModel(); 
    }

    private object GetViewModel()
    {
        var vm = new MvvmToolbarManagerViewModel();

        var mm = new MvvmToolbarViewModel() { DisplayMode = ToolbarDisplayMode.MainMenu };
        var tb = new MvvmToolbarViewModel() { StretchToolbar = true };

        var file = new MvvmToolbarMenuItemViewModel() { Header = "_File" };
        var edit = new MvvmToolbarMenuItemViewModel() { Header = "_Edit" };
        var view = new MvvmToolbarMenuItemViewModel() { Header = "_View" };
        var help = new MvvmToolbarMenuItemViewModel() { Header = "_Help" };

        file.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_New", Command = new MvvmToolbarItemCommand(), CommandParameter = "New Item", Glyph = LoadImage("Icons/Bars/New.svg")});
        file.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_Open", Command = new MvvmToolbarItemCommand(), CommandParameter = "Open Item", Glyph = LoadImage("Icons/Bars/Open.svg") });
        file.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_Save", Command = new MvvmToolbarItemCommand(), CommandParameter = "Save Item", Glyph = LoadImage("Icons/Bars/Save.svg") });
        file.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_Exit", ShowSeparator = true, Command = new MvvmToolbarItemCommand(), CommandParameter = "Exit Item" });
        
        edit.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_Cut", Command = new MvvmToolbarItemCommand(), CommandParameter = "Cut Item" , Glyph = LoadImage("Icons/Bars/Cut.svg") });
        edit.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "C_opy", Command = new MvvmToolbarItemCommand(), CommandParameter = "Copy Item" , Glyph = LoadImage("Icons/Bars/Copy.svg") });
        edit.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_Paste", Command = new MvvmToolbarItemCommand(), CommandParameter = "Paste Item" , Glyph = LoadImage("Icons/Bars/Paste.svg") });
        
        view.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "Zoom _In", Command = new MvvmToolbarItemCommand(), CommandParameter = "Zoom In Item" });
        view.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "Zoom _Out", Command = new MvvmToolbarItemCommand(), CommandParameter = "Zoom Out Item" });
        
        help.Items.Add(new MvvmToolbarButtonItemViewModel() { Header = "_About", Command = new MvvmToolbarItemCommand(), CommandParameter = "About Item", Glyph = LoadImage("Icons/Bars/Info.svg") });
        
        mm.Items.Add(file);
        mm.Items.Add(edit);
        mm.Items.Add(view);
        mm.Items.Add(help);
        
        vm.TopToolbars.Add(mm);

        var group = new MvvmToolbarCheckGroupViewModel() { Type = ToolbarItemCheckType.Radio };
        
        var left = new MvvmToolbarCheckItemViewModel() { Header = "Left", Glyph = LoadImage("Icons/Bars/AlignLeft.svg"), IsChecked = true };
        var center = new MvvmToolbarCheckItemViewModel() { Header = "Center", Glyph = LoadImage("Icons/Bars/AlignCenter.svg") };
        var right = new MvvmToolbarCheckItemViewModel() { Header = "Right", Glyph = LoadImage("Icons/Bars/AlignRight.svg") };
        
        group.Items.Add(left);
        group.Items.Add(center);
        group.Items.Add(right);
        
        tb.Items.Add(group);
        
        vm.TopToolbars.Add(tb);

        var sb = new MvvmToolbarViewModel() { DisplayMode = ToolbarDisplayMode.StatusBar };

        var progress = new MvvmToolbarTextItemViewModel() { Header = "Progress: " };
        sb.Items.Add(progress);
            
        vm.BottomToolbars.Add(sb);
        
        return vm;
    }

    IImage LoadImage(string name)
    {
        try
        {
            var svgSource = SvgSource.Load(name, new Uri("avares://DemoCenter/Assets/", UriKind.Absolute), null);
            return new SvgImage { Source = svgSource };
        }
        catch(Exception)
        {
            return null;
        }
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}