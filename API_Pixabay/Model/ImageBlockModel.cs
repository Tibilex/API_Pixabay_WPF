using API_Pixabay.Helpers;

namespace API_Pixabay.Model
{
    public class ImageBlockModel : ObservableObject
    {
        private string _imageURL;
        private string _imageLikes;
        private string _imageComments;
        private string _imageTag;
        private string _imageDownloadURL;

        public string Image
        {
            get => _imageURL; 
            set 
            { 
                _imageURL = value;
                OnPropertyChanged("Image");
            }
        }
        public string ImageLikes
        {
            get => _imageLikes;
            set
            {
                _imageLikes = value;
                OnPropertyChanged("ImageLikes");
            }
        }

        public string ImageComments
        {
            get => _imageComments;
            set
            {
                _imageComments = value;
                OnPropertyChanged("ImageComments");
            }
        }
        public string ImageTag
        {
            get => _imageTag;
            set
            {
                _imageTag = value;
                OnPropertyChanged("ImageTag");
            }
        }

        public string ImageDownloadURL
        {
            get => _imageDownloadURL;
            set
            {
                _imageDownloadURL = value;
                OnPropertyChanged("ImageDownloadURL");
            }
        }

        public ImageBlockModel(string imageURL)
        {
            Image = imageURL;
        }

        public ImageBlockModel(string imageURL,string imgLikes, string imgComments, string imageTag, string imageDownloadURL)
        {
            Image = imageURL;
            ImageLikes = imgLikes;
            ImageComments = imgComments;
            ImageTag = imageTag;
            ImageDownloadURL = imageDownloadURL;
        }
    }
}
