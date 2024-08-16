using System;
using System.Threading.Tasks;
using System.Windows;

namespace Crawler
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = "https://www.spreetropol.de/index.php/impressum/";
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Clickhandler to start the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crawlButton_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();
            crawlButton.IsEnabled = false;
            crawlButton.Content = "processing";
            this.StartCrawlingAsync();
        }

        /// <summary>
        /// Method that contains the "BI" of this programm
        /// </summary>
        /// <returns></returns>
        private async Task StartCrawlingAsync()
        {
            string websiteContent = await Utils.GetWebsite(url);
            contentFrame.Content = websiteContent;
            resultList.Items.Add($"crawled website: {url} ");

            string number = Utils.ExtractPhoneNumber(websiteContent);
            resultList.Items.Add($"found phone number: {number} ");

            int secondQuartet = Int16.Parse(number.Substring(4, 4));
            resultList.Items.Add($"found second quartet: {secondQuartet} ");

            int numberFibonacci = Utils.CalculateFibonacci(secondQuartet);
            resultList.Items.Add($"found fibonacci number: {numberFibonacci} ");
            this.resultList.Visibility = Visibility.Visible;

            crawlButton.IsEnabled = true;
            crawlButton.Content = "Start Crawling";
        }
    }
}
