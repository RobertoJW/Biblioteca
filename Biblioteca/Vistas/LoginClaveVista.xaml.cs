namespace Biblioteca.Vistas;

public partial class LoginClaveVista : ContentView
{
	public Border ClaveBorder => BorderClave;
    public Label LabelPublic => ContraseñaErrorLabel;
    public Entry EntryPublic => PasswordEntry;

    public LoginClaveVista()
	{
		InitializeComponent();
		BindingContext = this; 
	}

	public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceHolderTextProperty);
        set => SetValue(PlaceHolderTextProperty, value);
    }

    public string Clave
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private bool _isPasswordVisible = false;
    public bool IsPassword => !_isPasswordVisible;

    // texto que se muestra como una etiqueta encima del campo de entrada
    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText),
        typeof(string), typeof(LoginClaveVista), string.Empty);

    // texto que aparece como PlaceHolder
    public static readonly BindableProperty PlaceHolderTextProperty = BindableProperty.Create(nameof(PlaceholderText),
        typeof(string), typeof(LoginClaveVista), string.Empty);

    // texto de la contraseña
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Clave),
        typeof(string), typeof(LoginClaveVista), string.Empty, BindingMode.TwoWay);

    // propiedad para poder cambiar la visibilidad de la contraseña
    public ImageSource IconoVisible => _isPasswordVisible 
        ? new FontImageSource { Glyph = Iconos.Iconos.ojoAbierto, FontFamily = "Iconos", Color = Colors.Gray }
        : new FontImageSource { Glyph = Iconos.Iconos.ojoCerrado, FontFamily = "Iconos", Color = Colors.Gray };

    private void IconoOjoClicked(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        OnPropertyChanged(nameof(IconoVisible));
        OnPropertyChanged(nameof(IsPassword));
    }

    private void EntryContrasenaVisible(object sender, FocusEventArgs e)
    {
        ClaveBorder.Stroke = Colors.Gray;
        
    }

    private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(PasswordEntry.Text) && PasswordEntry.IsFocused)
        {
            ClaveBorder.Stroke = Colors.Gray;
            ContraseñaErrorLabel.IsVisible = false;
        }
    }

    private void OnEyeIconClicked(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        OnPropertyChanged(nameof(IconoVisible));
        OnPropertyChanged(nameof(IsPassword));
    }
}