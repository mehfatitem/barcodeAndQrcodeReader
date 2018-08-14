using AudioManager;
using BarocodeReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace BarocodeReader
{
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        private async void BarkodOku(object sender, EventArgs e)
        {
            try
            {
                var scanPage = new ZXingScannerPage();

                await Navigation.PushAsync(scanPage);

                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        try
                        {
                            DependencyService.Get<IAudio>().PlayAudioFile("http://m.egm.gov.tr/egm_cocuk/barcode_voice.mp3");
                            //DependencyService.Get<IAudio>().PlayAudioFileFromLocal("barcode_voice.mp3");
                        }
                        catch(Exception ex)
                        {
                            await DisplayAlert("Scanned Voice Error", ex.Message, "OK");
                        }
                        finally
                        {
                            barcode.Text = result.Text;
                        }
                    });
                };
            }
            catch (Exception ex)
            {
                await DisplayAlert("Scanned Error", ex.Message, "OK");
            }
            finally
            {

            }
        }
    }
}
