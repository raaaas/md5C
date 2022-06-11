using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace md5C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   //https://md5decrypt.net/en/Api/api.php?hash=fc94426463f5395171d6db6b60848cf5&hash_type=md5&email=rsp_emperor@yahoo.com&code=69e3145e1e10ccdf
            string hash = hashe.Text.ToString();
            switch (hash.Length)
            {
                case 32:
                    Crackit(hash, "md5");
                    break;
                case 40:
                    Crackit(hash, "sha1");
                    break;
                case 64:
                    Crackit(hash, "sha256");
                    break;
                case 126:
                    Crackit(hash, "sha512");
                    break;
                case 20:
                    Crackit(hash, "ntlm");
                    break;


            }
            /*
            if (hash.Length == 32)//md5-4
            {
                Crackit(hash, "md5");
                break;
            }
            if(hash.Length == 40)//sha-1
            {
                Crackit(hash, "sha1");
                break;
            }
            if (hash.Length == 64)//SHA256 
            {
                Crackit(hash, "SHA256");
                break;
            }
            if (hash.Length == 126)//SHA512  
            {
                Crackit(hash, "SHA512");
                break;

            }
            if (hash.Length == 20)//ntlm   
            {
                Crackit(hash, "ntlm");
                break;

            }
            else
            {
                cracked.Text += " i dont know what fuck is this hash!";
                break;
            }*/
        }

        private void Crackit(string hash,string type)
        {
            WebClient client = new WebClient();
            string content = client.DownloadString("https://md5decrypt.net/en/Api/api.php?hash=" + hash + "&hash_type=" + type + "&email=rsp_emperor@yahoo.com&code=69e3145e1e10ccdf");
            // The stream data is used here.

            if (content.ToString() == "ERROR CODE : 005")
            {
                cracked.Text += "fuck you hash is invalid\r\n";

            }
            else if (content.ToString() == "ERROR CODE : 004")
            {
                cracked.Text += "fuck you type hash is invalid\r\n";

            }
            else
            {
                cracked.Text += hash + " :: " + content.ToString()+ "\r\n";

            }
            
           // string downloadString = client.DownloadString("http://www.gooogle.com");


        }

        private void clearhash(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            hashe.Text = string.Empty;
            hashe.Foreground = Brushes.Green;
            hashe.GotFocus -= clearhash;
        }

        private void diemf(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void movebitch(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
