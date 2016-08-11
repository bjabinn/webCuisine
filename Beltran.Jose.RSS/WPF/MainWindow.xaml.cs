using System.ComponentModel;
using System.Windows;
using RssLibrary;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Channel _ch;

        private void btnUpdateRSS_Click(object sender, RoutedEventArgs e)
        {
            BtnUpdateRss.Content = "Getting Feeds...";

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GridFeeds.ItemsSource = _ch.Items;
            WebBrowser1.DataContext = _ch.Items;
            BtnUpdateRss.Content = "Get Feeds of Channel9";
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _ch = new RssFeader("https://channel9.msdn.com/feeds/rss").GetWholeChannel();
        }
    }

}
