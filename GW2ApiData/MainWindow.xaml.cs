using System;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;
using System.Net.Http;
using System.Diagnostics;

namespace GW2ApiData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private static UserKeyData userKey = new UserKeyData();
        private static UserData userData = new UserData();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {

            var ah = ActualHeight;
            var aw = ActualWidth;
            var h = Height;
            var w = Width;
            Debug.WriteLine("ActualHeight(updated height value): {0}, ActualWidth(updated width value): {1}, Height(before size change): {2}, Width(before size change): {3}", ah, aw, h, w);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userDataAsJson = "";

            if (keyTextBox.Text != "")
            {
                userKey.setKey(keyTextBox.Text);
                string url = String.Format("{0}{1}{2}", userKey.getBaseAddress, userKey.getAccountAccessor, userKey.getKey);
                var task = Task.Run(() => client.GetStringAsync(url));
                task.Wait();
                userDataAsJson = task.Result;
            }
            else
                MessageBox.Show("Error: Textbox is empty!");
            Debug.WriteLine($"this is userDataAsJson: { userDataAsJson}");
            userData = JsonSerializer.Deserialize<UserData>(userDataAsJson);
            Debug.WriteLine($"this is userData: {userData}");
            outputTextBox.Text = userData.ToString();
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            keyTextBox.Text = "FD6AE079-B9E3-F24D-B612-E136FDD5B1E2BE134C44-5140-430D-BEEA-A1FC7E91FE9E";
        }
        
    }
}
