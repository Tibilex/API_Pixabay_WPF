using API_Pixabay.Helpers;
using API_Pixabay.Model;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

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
        

        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand SortRedCommand { get; private set; }
        public RelayCommand SortGreenCommand { get; private set; }
        public RelayCommand SortBlueCommand { get; private set; }
        public RelayCommand SortPurpleCommand { get; private set; }
        public RelayCommand SortBlackCommand { get; private set; }
        public RelayCommand SortWhiteCommand { get; private set; }
        public RelayCommand SortOrangeCommand { get; private set; }
        public RelayCommand DownloadCommand { get; private set; }

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
            SortRedCommand = new RelayCommand(obj => SortRed());
            SortGreenCommand = new RelayCommand(obj => SortGreen());
            SortBlueCommand = new RelayCommand(obj => SortBlue());
            SortPurpleCommand = new RelayCommand(obj => SortPurple());
            SortBlackCommand = new RelayCommand(obj => SortBlack());
            SortWhiteCommand = new RelayCommand(obj => SortWhite());
            SortOrangeCommand = new RelayCommand(obj => SortOrange());
            DownloadCommand = new RelayCommand(obj => DownloadImage());
        }

        private void DownloadImage()
        {
            _savFileDialog.Filter = _imageFormatFilter;
            _savFileDialog.ShowDialog();
            if (_savFileDialog.ShowDialog() == true)
            {

            }
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
        private void SortRed() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Red&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortGreen() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Green&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortBlue() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Blue&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortPurple() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Purple&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortBlack() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Black&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortWhite() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=White&image_type=photo&per_page=200"; GetPhoto(API);}
        private void SortOrange() { string API = $"https://pixabay.com/api/?key=29849703-9f3414504f38cae34a4c64380&q=Orange&image_type=photo&per_page=200"; GetPhoto(API);}


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
                    data.hits[i].tags));
            }
        }
    }
}
