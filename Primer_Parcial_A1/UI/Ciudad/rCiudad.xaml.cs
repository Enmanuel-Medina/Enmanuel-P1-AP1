using System.Windows;
using Primer_Parcial_A1.Entidades;
using Primer_Parcial_A1.BLL;
using RegistroPrestamos.BLL;

namespace Primer_Parcial_A1.UI.Ciudad
{
    /// <summary>
    /// Interaction logic for rCiudad.xaml
    /// </summary>
    public partial class rCiudad : Window
    {
        rCiudad ciudad;
        public rCiudad()
        {
            InitializeComponent();
            ciudad = new rCiudad();
            this.DataContext = ciudad;
        }
        //LIMPIAR
        private void Limpiar()
        {
            this.ciudad = new rCiudad();
            this.DataContext = ciudad;
        }
        //VALIDAR
        private bool Validar()
        {
            bool esValido = true;
            if (CiudadIdTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        //BUSCAR
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = Ciudad_BLL.Buscar(Utilities.ToInt(CiudadIdTextbox.Text));
            if (ciudad != null)
                this.ciudad = ciudad;
            else
                this.ciudad = new rCiudad();

            this.DataContext = this.ciudad;
        }
        //NUEVO
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //GUARDAR
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = Ciudad_BLL.Guardar(ciudad);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //ELIMINAR
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Ciudad_BLL.Eliminar(Utilities.ToInt(CiudadIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
