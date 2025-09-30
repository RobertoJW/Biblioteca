using Biblioteca.Servicios;
using Biblioteca.Modelo;

namespace Biblioteca.AppClass
{
    public partial class MainPage : ContentPage
    {
        private readonly GoogleBooksClient GBK = new GoogleBooksClient(); 
        public MainPage()
        {
            InitializeComponent();
            CargarLibros(); 
        }

        private void BtnBuscarLibro(object sender, EventArgs e)
        {
            
        }

        private async void CargarLibros()
        {
            var librosPopulares = await GBK.CargarLibrosPopulares();
            var librosNuevos = await GBK.CargarLibrosNuevos();
            var librosBestSellers = await GBK.CargarLibrosMasVendidos();

            coleccionLibrosPopulares.ItemsSource = librosPopulares; 
            coleccionLibrosBestSellers.ItemsSource = librosBestSellers;
            coleccionLibrosNuevos.ItemsSource = librosNuevos;
        }
    }
}
