using Microsoft.Maui.Controls;

namespace gguachaminT2.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        string usuarioIngresado = TxtUsuario.Text;
        string contrasenaIngresado = TxtContrasena.Text;
        bool ingresa = false;
        List<string> usuarios = new List<string> { "Carlos", "Ana", "Jose" };
        List<string> contraseñas = new List<string> { "carlos123", "ana123", "jose123" };

        for (int i = 0; i < usuarios.Count; i++)
        {
            if (usuarios[i] == usuarioIngresado && contraseñas[i] == contrasenaIngresado)
            {
                Navigation.PushAsync(new Vistas.ReporteNotas(usuarioIngresado));
                ingresa = true;
            }
        }
        if (!ingresa)
        {
            DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "Cerrar");
            TxtContrasena.Text = "";
            TxtUsuario.Text = "";
        }
    }
}