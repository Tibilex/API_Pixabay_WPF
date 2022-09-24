using System.Collections.Generic;

namespace API_Pixabay.Model
{
    public class PhotoCollectionModel
    {
        public int total { get; set; }
        public int totalHits { get; set; }
        public List<PhotoModel> hits { get; set; }

   
    }
}
