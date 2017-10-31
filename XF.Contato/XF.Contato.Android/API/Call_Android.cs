using Xamarin.Forms;
using XF.Contato.Droid.API;

[assembly: Dependency(typeof(Call_Android))]
namespace XF.Contato.Droid.API
{
    using Android.Content;
    using Android.Net;
    using Android.Telephony;
    using System.Linq;
    using XF.Contato.API;
    using XF.Contato.Model;

    /// <summary>
    /// Defines the implementatio on Android to call contatos.
    /// </summary>
    public class Call_Android : ICall
    {
        #region Methods

        /// <summary>
        /// Realizes a call for a contato.
        /// </summary>
        /// <param name="contato">The contato to call.</param>
        public void Call(ContatoModel contato)
        {
            if (Forms.Context != null)
            {
                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + contato.Numero));
                
                if (Forms.Context.PackageManager.QueryIntentServices(intent, 0).Union(Forms.Context.PackageManager.QueryIntentActivities(intent, 0)).Any())
                {
                    Forms.Context.StartActivity(intent);
                }
                else
                {
                    if (TelephonyManager.FromContext(Forms.Context).PhoneType != PhoneType.None)
                    {
                        Forms.Context.StartActivity(intent);
                    }                    
                }
            }
        }

        #endregion
    }
}