using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace API_Pixabay.View
{
    /// <summary>
    /// Логика взаимодействия для ImageBlock.xaml
    /// </summary>
    public partial class ImageBlock : UserControl
    {
        public ImageBlock()
        {
            InitializeComponent();
            this.Loaded += ImageBlock_Loaded;
        }

        private void ImageBlock_Loaded(object sender, RoutedEventArgs e)
        {
            DownloadFileCommand?.Execute(null);
        }

        public ICommand DownloadFileCommand
        {
            get { return (ICommand)GetValue(DownloadCommandProperty); }
            set { SetValue(DownloadCommandProperty, value); }
        }

        public static readonly DependencyProperty DownloadCommandProperty =
                DependencyProperty.Register("DownloadFileCommand", typeof(ICommand), typeof(ImageBlock));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
