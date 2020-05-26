using RegistroPersonas.BLL;
using RegistroPersonas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroPersonas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personas persona = new Personas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = persona;

            PersonaIdTextBox.Text = "0";
        }
        

        private void Limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
        }
        private bool existeEnLaBaseDeDatos()
        {
            Personas personaAnterior = PersonaBLL.Buscar(persona.PersonaId);

            return persona != null;
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = persona;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int.TryParse(PersonaIdTextBox.Text, out id);

            Personas personaAnterior = PersonaBLL.Buscar(id);

            if (personaAnterior != null)
            {
                persona = personaAnterior;
                
            }
            else
            {
                MessageBox.Show(" no encontrada");
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();

        }
        private bool validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
                paso = false;
            else
            {
                try
                {
                    int i = Convert.ToInt32(PersonaIdTextBox.Text);
                }
                catch (FormatException)
                {
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
                paso = false;
            else
            {
                foreach (var caracter in NombreTextBox.Text)
                {
                    if (!char.IsLetter(caracter))
                        paso = false;
                }
            }

            if (paso == false)
                MessageBox.Show("INVALIDO");

            return paso;
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!validar())
                return;

            if (persona.PersonaId == 0)
            {
                paso = PersonaBLL.Guardar(persona);
            }
            else
            {
                if (existeEnLaBaseDeDatos())
                {
                    paso = PersonaBLL.Modificar(persona);
                }
                else
                {
                    MessageBox.Show("No se puede modificar no existe");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
        
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int.TryParse(PersonaIdTextBox.Text, out id);

            if (PersonaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar no existe");
            }
        }
    }
}
