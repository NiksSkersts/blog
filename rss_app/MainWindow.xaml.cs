using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace rss_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _password;
        private string _username;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            _password = password.Text;
            _username = username.Text;
            using (var res = new HttpClient())
            {
                res.BaseAddress = new Uri("https://localhost:5001/");
                var responseTask = res.GetAsync(_username + "/" + _password);
                responseTask.Wait();
                var result = responseTask.Result;
                //var httpRequest = (HttpWebRequest)WebRequest.Create(url);


                //var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    var result = streamReader.ReadToEnd();
                //}

                //Console.WriteLine(httpResponse.StatusCode);
            }
        }
    }
}
