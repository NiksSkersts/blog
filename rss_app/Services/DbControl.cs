using System.Collections.ObjectModel;
using System.Data.SQLite;
using CodeHollow.FeedReader;

namespace rss_app.Models
{
    public class DbControl
    {
        #region SQL
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Models/database.db;Compress=True;");
        #endregion
        public static ObservableCollection<Feed> Feeds;
    }
}