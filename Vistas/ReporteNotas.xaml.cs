namespace gguachaminT2.Vistas;

public partial class ReporteNotas : ContentPage
{
	public ReporteNotas()
	{
		InitializeComponent();
	}

    private void btnCalcularNotaFinal_Clicked(object sender, EventArgs e)
    {
        if (pkEstudiantes.SelectedIndex == -1)
        {
            DisplayAlert("Alerta de Validación", "Seleccione un estudiante!", "Cerrar");
        }
        else
        {
            string nombre = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();
            string fecha = dpFecha.Date.ToString();
            if (validarEntrada(TxtNotaSeg1.Text) && validarEntrada(TxtNotaSeg2.Text) && validarEntrada(TxtNotaExm1.Text) && validarEntrada(TxtNotaExm2.Text))
            {
                double notaParcial1 = int.Parse(TxtNotaSeg1.Text) * 0.3 + int.Parse(TxtNotaExm1.Text) * 0.2;
                double notaParcial2 = int.Parse(TxtNotaSeg2.Text) * 0.3 + int.Parse(TxtNotaExm2.Text) * 0.2;
                double notaFinal = notaParcial1 + notaParcial2;
                DisplayAlert("Alerta", "Nombre: " + nombre+"\nFecha: "+fecha+"\nNota Parcial 1: "+notaParcial1.ToString("F2")
                    + "\nNota Parcial 2: "+notaParcial2.ToString("F2") + "\nNota Final: "+notaFinal.ToString("F2")
                    + "\nEstado: "+ validarEstadoNota(notaFinal), "Cerrar");
        }
            else
            {
                DisplayAlert("Alerta de Validación", "Una de las notas ingresadas no es un valor entero entre 0 y 10!", "Cerrar");
            }
        }
        
    }
    private string validarEstadoNota(double nota)
    {
        if (nota >= 7) 
        {
            return "Aprobado";
        }
        else if (nota >= 5 && nota <= 6.9) 
        {
            return "Complementario";
        }
        else
        {
            return "Reprobado";
        }
    }
    private bool validarEntrada(string entrada)
    {
        if (EsNumeroEntero(entrada) && EsNumeroEnRango(entrada))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool EsNumeroEntero(string texto)
    {
        return int.TryParse(texto, out _);
    }

    private bool EsNumeroEnRango(string texto)
    {
        if (int.TryParse(texto, out int numero))
        {
            return numero >= 0 && numero <= 10;
        }
        return false;
    }
}