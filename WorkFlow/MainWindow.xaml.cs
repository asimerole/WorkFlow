using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkFlow;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    // Bottom-Right resizer (Corner)
    private void ResizeRThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (Width + e.HorizontalChange > MinWidth)
            Width += e.HorizontalChange;
    
        if (Height + e.VerticalChange > MinHeight)
            Height += e.VerticalChange;
    }
    
    // Bottom-Left resizer (Corner)
    private void ResizeLThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (Width - e.HorizontalChange > MinWidth)
        {
            Left += e.HorizontalChange; 
            Width -= e.HorizontalChange; 
        }
        
        if (Height + e.VerticalChange > MinHeight)
        {
            Height += e.VerticalChange;
        }
    }
    
    // Left side resizer
    private void LeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (Width - e.HorizontalChange > MinWidth)
        {
            Left += e.HorizontalChange;
            Width -= e.HorizontalChange;
        }
    }

    // Right side resizer
    private void RightThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (Width + e.HorizontalChange > MinWidth)
            Width += e.HorizontalChange;
    }
    
    // Bottom side resizer
    private void BottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        if (Height + e.VerticalChange > MinWidth)
        {
            Height += e.VerticalChange;
        }
    }

    // Dragging a window
    private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
    
    // Collapse window
    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    
    // Maximize/Restore Window
    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            ((Button)sender).Content = "🗖";
        }
        else
        {
            WindowState = WindowState.Maximized;
            ((Button)sender).Content = "🗗";
        }
    }
    
    // Close window
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    // Double-click on top panel for full screen mode
    private DateTime _lastTopPanelClickTime;
    private void TopPanelBorder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if ((DateTime.Now - _lastTopPanelClickTime).TotalMilliseconds < 200)
        {
            this.WindowState = this.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
            _lastTopPanelClickTime = DateTime.MinValue;
        }
        else
        {
            _lastTopPanelClickTime = DateTime.Now;
        }
    }
    
    // Home Button click
    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {
        HomePage.Visibility = Visibility.Visible;
        TimerPage.Visibility = Visibility.Collapsed;
    }
    
    // Timer Button click
    private void TimerButton_Click(object sender, RoutedEventArgs e)
    {
        HomePage.Visibility = Visibility.Collapsed;
        TimerPage.Visibility = Visibility.Visible;
    }
}