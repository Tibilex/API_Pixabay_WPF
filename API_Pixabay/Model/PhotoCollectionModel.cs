using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Pixabay.Model
{
    public class PhotoCollectionModel
    {
        public int total { get; set; }
        public int totalHits { get; set; }
        public List<PhotoModel> hits { get; set; }

   
    }
}
