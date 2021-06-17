using System;
using System.Collections.Generic;
using System.Text;
using app.Models;
using ReactiveUI;

namespace app.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public static raftypoileidlvContext Db = new();
    }
}
