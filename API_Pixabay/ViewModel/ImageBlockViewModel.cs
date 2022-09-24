using API_Pixabay.Helpers;
using API_Pixabay.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace API_Pixabay.ViewModel
{
    public class ImageBlockViewModel : ObservableObject
    {
        private string _pixabay_API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=programming&image_type=photo&per_page=200";
        private WebClient client;
        private PhotoCollectionModel data;
        private SaveFileDialog _savFileDialog;

        private string _imageFormatFilter =
            $"Все файлы изображений (*.BMP,*.DIB,*.RLE,*.JPG,*.JPEG,*.JPE,*.JFIF,*.GIF,*.EMF,*.WMF,*.TIFF,*.PNG,*.ICO)|*.bmp;*.dib;*.rle;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.emf;*.wmf;*.tiff;*.png;*.ico|" +
            "BMP (*.BMP,*.DIB,*.RLE)|*.bmp;*.dib;*.rle|" +
            "JPEG (*.JPG,*.JPEG,*.JPE,*.JFIF)|*.jpg;*.jpeg;*.jpe;*.jfif|" +
            "GIF (*.GIF)|*.gif|" +
            "EMF (*.EMF)|*.emf|" +
            "WMF (*.WMF)|*.wmf|" +
            "TIFF (*.TIFF)|*.tiff|" +
            "PNG (*.PNG)|*.png|" +
            "ICO (*.ICO)|*.ico|" +
            "Все файлы (*.*)|*.*";

        public ObservableCollection<ImageBlockModel> ImagesList { get; set; }
        public string SearchingText { get; set; }
        public string SelectedItem { get; set; }
        public string DownloadLink { get; set; }
        public string Color { get; set; }


        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand SortRedCommand { get; private set; }
        public RelayCommand SortGreenCommand { get; private set; }
        public RelayCommand SortBlueCommand { get; private set; }
        public RelayCommand SortPurpleCommand { get; private set; }
        public RelayCommand SortBlackCommand { get; private set; }
        public RelayCommand SortWhiteCommand { get; private set; }
        public RelayCommand SortOrangeCommand { get; private set; }
        public RelayCommand SortYellowCommand { get; private set; }
        public RelayCommand DownloadCommand { get; private set; }
        public RelayCommand TestCommand { get; private set; }

        public ImageBlockViewModel()
        {
            client = new();
            data = new();
            _savFileDialog = new();
            ImagesList = new();
            GetPhoto(_pixabay_API);
            Commands();
        }

        private void Commands()
        {
            SearchCommand = new RelayCommand(obj => SearchPhoto());
            SortRedCommand = new RelayCommand(obj => SortForColors("Red"));
            SortGreenCommand = new RelayCommand(obj => SortForColors("Green"));
            SortBlueCommand = new RelayCommand(obj => SortForColors("Blue"));
            SortPurpleCommand = new RelayCommand(obj => SortForColors("Purple"));
            SortBlackCommand = new RelayCommand(obj => SortForColors("Black+White"));
            SortWhiteCommand = new RelayCommand(obj => SortForColors("Gray"));
            SortOrangeCommand = new RelayCommand(obj => SortForColors("Orange"));
            SortYellowCommand = new RelayCommand(obj => SortForColors("Yellow"));
            DownloadCommand = new RelayCommand(obj => DownloadImage());
            TestCommand = new RelayCommand(obj => test("123"));
        }

        private void test(string test)
        {

        }

        private void DownloadImage()
        {
            if (DownloadLink != null)
            {
                _savFileDialog.Filter = _imageFormatFilter;
                if (_savFileDialog.ShowDialog() == true)
                {
                    using (WebClient client = new())
                    {
                        client.DownloadFile(DownloadLink, _savFileDialog.FileName);
                    }
                }
            }
            else { MessageBox.Show("Ссылка не найдена"); }
        }

        private void SearchPhoto()
        {
            if (SearchingText != null)
            {
                SearchingText.Replace(" ", "+");
                string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q={SearchingText}&image_type=photo&per_page=200";
                GetPhoto(API);
            }
            else
            {
                SearchingText = "Что ищем?";
            }
        }

        private void SortForColors(string color) 
        { 
            string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q={color}&image_type=photo&per_page=200";
            GetPhoto(API);
        }

        private async void GetPhoto(string api)
        {

            string ans_str = client.DownloadString(api);
            data = JsonSerializer.Deserialize<PhotoCollectionModel>(ans_str);
            if (ImagesList != null)
            {
                ImagesList.Clear();
            }
            await Task.Delay(1);
            for(int i = 0; i < data.hits.Count; i++)
            {
                ImagesList.Add(new ImageBlockModel(data.hits[i].webformatURL,
                    data.hits[i].likes.ToString(),
                    data.hits[i].comments.ToString(),
                    data.hits[i].tags,
                    data.hits[i].largeImageURL.ToString()));

            }
        }
    }
}
