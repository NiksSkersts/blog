using System.Collections.ObjectModel;
using app.Models;
using ReactiveUI;

namespace app.ViewModels
{
    public class Authors : ViewModelBase
    {
        private ObservableCollection<Author> _collection = new(Db.Authors);
        public ObservableCollection<Author> _Authors
        {
            get => _collection;
            set => this.RaiseAndSetIfChanged(ref value, value);
        }
    }
}