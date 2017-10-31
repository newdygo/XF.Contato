
using Xamarin.Forms;
using XF.Contato.View.Contato;
using XF.Contato.ViewModel;

namespace XF.Contato
{
    public partial class App : Application
    {
        public static ContatoViewModel ContatoVM { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeApplication();

            MainPage = new NavigationPage(new MainPage() { BindingContext = App.ContatoVM });
        }

        private void InitializeApplication()
        {
            if (ContatoVM == null)
                ContatoVM = new ContatoViewModel();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
