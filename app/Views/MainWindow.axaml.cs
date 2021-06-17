using System;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices.ComTypes;
using app.Models;
using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

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
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
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
            _btnAdd.Click += AddToGrid;
            _btnSave.Click += SaveToDb;
            _gridPosts.PropertyChanged += OnDataGridChange;
            _gridPosts.RowEditEnded += GridPostsOnRowEditEnded;

        }

        private void AddToGrid(object? sender, RoutedEventArgs e)
        {
            //posts =0
            //pictures =1
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
        }

        private void SetDataContext()
        {
            _gridPosts.DataContext = new Posts();
        }
    }
}