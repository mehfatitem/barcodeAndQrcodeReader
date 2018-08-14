using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarocodeReader;
using ZXing.Mobile;
using Xamarin.Forms;
using BarcodeReader.Droid.DependencyService;

[assembly: Dependency(typeof(QrCodeScanningService))]
namespace BarcodeReader.Droid.DependencyService
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions()
            {

            };
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Barkodu okutunuz",
                BottomText = "Barkodu okutunuz"
            };
            var scanResult = await scanner.Scan(optionsCustom);
            return (scanResult != null) ? scanResult.Text : string.Empty;
        }
    }
}