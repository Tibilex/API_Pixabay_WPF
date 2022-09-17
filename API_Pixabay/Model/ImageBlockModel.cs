using API_Pixabay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Pixabay.Model
{
    public class ImageBlockModel : ObservableObject
    {
        private string _imageURL;
        private string _imageLikes;
        private string _imageComments;
        private string _imageTag;

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

        public ImageBlockModel(string imageURL)
        {
            Image = imageURL;
        }

        public ImageBlockModel(string imageURL,string imgLikes, string imgComments, string imageTag)
        {
            Image = imageURL;
            ImageLikes = imgLikes;
            ImageComments = imgComments;
            ImageTag = imageTag;
        }
    }
}
