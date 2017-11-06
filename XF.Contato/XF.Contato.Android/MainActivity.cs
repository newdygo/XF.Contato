
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Media;
using XF.Contato.API;

namespace XF.Contato.Droid
{
    [Activity(Label = "XF.Contato", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode != Result.Canceled)
            {
                MessagingCenter.Send(DependencyService.Get<IContato>(), "thumb", (await data.GetMediaFileExtraAsync(Forms.Context)).Path);
            }
        }
    }
}

