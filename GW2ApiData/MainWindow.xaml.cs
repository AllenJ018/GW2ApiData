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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userDataAsJson = "";

            if (keyTextBox.Text != "")
            {
                userKey.setKey(keyTextBox.Text);
                string url = String.Format("{0}{1}{2}", userKey.getBaseAddress, userKey.getAccountAccessor, userKey.getKey);
                // var response = asyncMethod(url);

                var task = Task.Run(() => client.GetStringAsync(url));
                task.Wait();
                var response = task.Result;
            }
            else
                MessageBox.Show("Error: Textbox is empty!");
            Debug.WriteLine($"this is userDataAsJson last call: { userDataAsJson}");
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            keyTextBox.Text = "FD6AE079-B9E3-F24D-B612-E136FDD5B1E2BE134C44-5140-430D-BEEA-A1FC7E91FE9E";
        }
    }
}
