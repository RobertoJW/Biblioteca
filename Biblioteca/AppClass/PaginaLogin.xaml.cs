namespace Biblioteca.AppClass;

public partial class PaginaLogin : ContentPage
{
    private int seleccion = 0; // 0 para iniciar sesion, 1 para registro

    public PaginaLogin()
	{
		InitializeComponent();
	}

    private async void OnLoginSelected(object sender, EventArgs e)
    {
        if (seleccion == 0) return;
        seleccion = 0;

        await SliderBackground.TranslateTo(-SelectorGrid.Width / 2, 0, 200, Easing.CubicOut);
        Grid.SetColumn(SliderBackground, 0);
        SliderBackground.TranslationX = 0;

        LoginTab.TextColor = Colors.Black;
        RegisterTab.TextColor = Colors.Gray;

        // Cambiar visibilidad y animar
        LoginForm.IsVisible = true;
        RegisterForm.Opacity = 0;
        RegisterForm.IsVisible = false;
        await LoginForm.FadeTo(1, 250, Easing.CubicIn);
    }

    private async void OnRegisterSelected(object sender, EventArgs e)
    {
        if (seleccion == 1) return;
        seleccion = 1;

        await SliderBackground.TranslateTo(SelectorGrid.Width / 2, 0, 200, Easing.CubicOut);
        Grid.SetColumn(SliderBackground, 1);
        SliderBackground.TranslationX = 0;

        LoginTab.TextColor = Colors.Gray;
        RegisterTab.TextColor = Colors.Black;

        // Cambiar visibilidad y animar
        LoginForm.IsVisible = false;
        RegisterForm.Opacity = 0;
        RegisterForm.IsVisible = true;
        await RegisterForm.FadeTo(1, 250, Easing.CubicIn);
    }

    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Lógica para manejar el evento de registro
    }

    private void OnCorreoTextChanged(object sender, TextChangedEventArgs e)
    {
        // Lógica para manejar el cambio de texto en el campo de correo
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        // Lógica para manejar el evento de toque
    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Lógica para manejar el evento de inicio de sesión
    }

    private void OnUserRegisterTextChanged(object sender, TextChangedEventArgs e)
    {
        // Lógica para manejar el cambio de texto en el campo de usuario de registro
    }

    private void OnCorreoRegisterTextChanged(object sender, TextChangedEventArgs e)
    {
        // Lógica para manejar el cambio de texto en el campo de contraseña de registro
    }

}