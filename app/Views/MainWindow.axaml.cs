using app.Models;
using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace app.Views
{
    public partial class MainWindow : Window
    {
        #region Declare
        private DataGrid GridPosts;
        private DataGrid GridPictures;


        #endregion
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            TieXamlToCode();
            SetDataContext();

        }

        private void TieXamlToCode()
        {
            GridPosts = this.Find<DataGrid>("GridPosts");
            GridPictures = this.Find<DataGrid>("GridPictures");
        }

        private void SetDataContext()
        {
            GridPosts.DataContext = new VmPosts();
            GridPictures.DataContext = new VmPictures();
        }
    }
}