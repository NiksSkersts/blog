using System.Collections.ObjectModel;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.ViewModels
{
    public class VmPictures : ViewModelBase
    {
        public ObservableCollection<Picture> Data => LoadData();
        private ObservableCollection<Picture> LoadData()
        {
            using (Db = new raftypoileidlvContext())
            {
                Db.Posts.Load();
                return new ObservableCollection<Picture>(Db.Pictures);   
            }
        }
    }
}