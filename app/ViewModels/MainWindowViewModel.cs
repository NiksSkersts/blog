using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace app.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Picture> Data => OnLoad();
        private raftypoileidlvContext _context;

        private ObservableCollection<Picture> OnLoad()
        {
            using (_context = new raftypoileidlvContext())
            {
                _context.Pictures.Load();
                return new ObservableCollection<Picture>(_context.Pictures);
            }
        }
    }
}