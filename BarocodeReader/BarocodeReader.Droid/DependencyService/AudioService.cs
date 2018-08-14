using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarocodeReader.Interfaces;
using Android.Media;
using Xamarin.Forms;
using BarocodeReader.Droid.DependencyService;

[assembly: Dependency(typeof(AudioService))]
namespace BarocodeReader.Droid.DependencyService
{
    public class AudioService : IAudio
    {
        public AudioService()
        { }

        public void PlayAudioFile(string uri)
        {
            var player = new MediaPlayer();
            player.SetDataSource(global::Android.App.Application.Context, global::Android.Net.Uri.Parse(uri));
            player.Prepare();
            player.Start();
        }

        public void PlayAudioFileFromLocal(string fileName)
        {
            var player = new MediaPlayer();
            var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);

            player.Prepared += (s, e) =>
            {
                player.Start();
            };

            player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
            player.Prepare();
        }
    }
}
