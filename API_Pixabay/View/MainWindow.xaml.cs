using API_Pixabay.Model;
using API_Pixabay.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace API_Pixabay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow? s_window;
        private ImageBlockViewModel _imageBlockViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _imageBlockViewModel = new();
            DataContext = _imageBlockViewModel;
            s_window = this;
        }

        private void MinimiseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MovingWindow(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                s_window.DragMove();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ImageBlockModel p = (ImageBlockModel)ImageList.SelectedItem;
            _imageBlockViewModel.DownloadLink =  p.ImageDownloadURL.ToString();
        }
    }
}
