using System.Collections.ObjectModel;
using app.Models;
using ReactiveUI;

namespace app.ViewModels
{
    public class Pictures : ViewModelBase
    {
        public ObservableCollection<Picture> _Pictures
        {
            get => new(Db.Pictures);
            set => this.RaiseAndSetIfChanged(ref value,value);
        }
    }
}