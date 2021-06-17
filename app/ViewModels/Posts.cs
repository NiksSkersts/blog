using System.Collections.ObjectModel;
using System.Reactive.Linq;
using app.Models;
using ReactiveUI;

namespace app.ViewModels
{
    public class Posts : ViewModelBase
    {
        public ObservableCollection<Post> _Posts
        {
            get => new(Db.Posts);
            set => this.RaiseAndSetIfChanged(ref value,value);
        }
    }
}