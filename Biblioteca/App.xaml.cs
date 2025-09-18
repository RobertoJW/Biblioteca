using Biblioteca.AppClass; 

namespace Biblioteca
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
