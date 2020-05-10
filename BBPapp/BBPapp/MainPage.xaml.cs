using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BBPapp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                     await Navigation.PopAsync();
                    mycode.Text = result.Text;
                    JObject o = JObject.Parse(result.Text);
                    string product = (string)o["product"];
                    string barcode = (string)o["barcode"];
                    string releaseDate = (string)o["releaseDate"];
                    bool issued = (bool)o["issued"];
                    IList<string> person = o["person"].Select(t => (string)t).ToList();

                    jsonresult.Text += product;
                    jsonresult.Text += "\n";

                
                    jsonresult.Text += barcode;
                    jsonresult.Text += "\n";

                   
                    jsonresult.Text += releaseDate;
                    jsonresult.Text += "\n";

                    
                    jsonresult.Text += issued;
                    jsonresult.Text += "\n";

                    jsonresult.Text += issued;

                    
                   
                    foreach (var i in person)
                    {
                        jsonresult.Text += i;
                        jsonresult.Text += "\n";
                    }
                    



                }
                );
            };
        }
    }
}
