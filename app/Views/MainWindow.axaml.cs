using System.Collections.ObjectModel;
using System.Linq;
using app.Models;
using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;

namespace app.Views
{
    public partial class MainWindow : Window
    {
        #region Declare
        private DataGrid _gridPosts;
        private DataGrid _gridPictures;
        private Button _btnSave;
        private Button _btnAdd;
        private TabControl _mainStrip;
        private ObservableCollection<Post> _dataPosts;
        private ObservableCollection<Author> _dataAuthors;
        private ComboBox _authorList = new ComboBox();
        #endregion

        public MainWindow()
        {
            EarlyInit();
            InitializeComponent();
            this.AttachDevTools();
            
        }

        private void EarlyInit()
        {
            _dataPosts = new Posts()._Posts;
            _dataAuthors = new Authors()._Authors;
        }
        private void SaveToDb(object? sender, RoutedEventArgs e)
        {
            ViewModelBase.Db.SaveChanges();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            TieXamlToCode();
            SetDataContext();
            SetUpDataGrid();
            _btnAdd.Click += AddToGrid;
            _btnSave.Click += SaveToDb;
            _gridPosts.PropertyChanged += OnDataGridChange;
            _gridPosts.RowEditEnded += GridPostsOnRowEditEnded;
            _gridPosts.PreparingCellForEdit += GridPostsOnPreparingCellForEdit;

        }

        private void GridPostsOnPreparingCellForEdit(object? sender, DataGridPreparingCellForEditEventArgs e)
        {
            
        }

        private void SetUpDataGrid()
        {
            #region Grid_Posts
            _gridPosts.AutoGenerateColumns = false;
            _gridPosts.Columns.AddRange(new DataGridColumn[]
            {
                new DataGridTextColumn
                {
                    Binding = new Binding("Title"),
                    Header = "Title"
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Description"),
                    Header = "Description"
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Body"),
                    Header = "Body",
                    MaxWidth = 200
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Date"),
                    Header = "Date",
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Published"),
                    Header = "Published",
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("IdAuthor"),
                    Header = "Published",
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Published"),
                    Header = "Published",
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Published"),
                    Header = "Published",
                },
                new DataGridTextColumn
                {
                    Binding = new Binding("Published"),
                    Header = "Published",
                },
            });
            #endregion
        }

        private void AddToGrid(object? sender, RoutedEventArgs e)
        {
            //posts =0
            //pictures =1
            _dataPosts.Add(new Post());
        }

        private void GridPostsOnRowEditEnded(object? sender, DataGridRowEditEndedEventArgs e)
        {
        }

        private void OnDataGridChange(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
        }
        
        private void TieXamlToCode()
        {
            _gridPosts = this.Find<DataGrid>("GridPosts");
            _gridPictures = this.Find<DataGrid>("GridPictures");
            _btnSave = this.Find<Button>("BtnSave");
            _btnAdd = this.Find<Button>("BtnAdd");
            _mainStrip = this.Find<TabControl>("MainStrip");
            _authorList = this.Find<ComboBox>("AuthorList");
        }

        private void SetDataContext()
        {
            _gridPosts.DataContext = _dataPosts;
            //_gridPictures.DataContext = new Pictures();
            _authorList.DataContext = _dataAuthors;
        }
    }
}