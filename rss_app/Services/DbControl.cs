using System.Collections.ObjectModel;
using System.Data.SQLite;
using CodeHollow.FeedReader;

namespace rss_app.Services
{
    public class DbControl
    {
        #region SQL
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=database.db;Compress=True;");
        #endregion
        public static ObservableCollection<Feed> Feeds;
    }
}