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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;


namespace ProyectoIPO2020_2021
{
    /// <summary>
    /// Lógica de interacción para Aplicacion.xaml
    /// </summary>
    public partial class Aplicacion : Window
    {
        
        private VentanaAyuda ventanaAyuda = new VentanaAyuda();
        private Apadrinado ventanaPadrinos = new Apadrinado();
        

        private static BitmapImage imgUsuario1 = new BitmapImage(new Uri("/Images/Mike-Wazowski.jpg", UriKind.Relative));
        private static Usuario usuario1 = new Usuario("Mario Torres Toledano", "Mario.Torres@gmail.com", "05285136F", 688455782, DateTime.Now, imgUsuario1, "123");
        
        
        
        public Aplicacion()
        {
            InitializeComponent();
            
            txtblockDetUser.Text = usuario1.correo;
            imgPerfil.Source = usuario1.img;
            lblNombre.Content = usuario1.nombre;
            txtblockDni.Text = usuario1.dni;
            lblTlf.Content = usuario1.n_tlf;
            lblFecha.Content = usuario1.ult_acceso;

 
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            ventanaAyuda.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
       
        private void btnConsultaApadrinado_Click(object sender, RoutedEventArgs e)
        {
            ventanaPadrinos.Show();
        }

        private void btnAñadirImagenPerro_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName,
                    UriKind.Absolute));
                    imgPerro.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            string sexo_perro = obtenerSexoPerro();
            
            StreamWriter escribir = new StreamWriter("TablaPerros.txt");
            escribir.WriteLine("Nombre " + " Sexo " + " Raza " + " Peso " + " Edad " + " Fecha de entrada " + " ¿Apadrinado? " + " Descripción ");
            escribir.WriteLine(txtboxNombrePerro.Text + " " + sexo_perro + " " + txtboxRazaPerro.Text + " " + txtboxPesoPerro.Text + " " + txtEdadPerro.Text + " " + dateFechaPerro.Text + " " + checkApadrinado.IsChecked + " " + txtboxDescripcion.Text);
            escribir.Close();
        }

        private string obtenerSexoPerro()
        {
            String sexo;
            if (radiobMacho == null)
            {
                sexo = (string)radiobHembra.Content;
            }
            else
            {
                sexo = (string)radiobMacho.Content;
            }
            return sexo;
        }



        private void CheckBoxLunes_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxLunesMa.IsEnabled = true;
            CheckBoxLunesTar.IsEnabled = true;
        }

        private void CheckBoxMartes_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxMartesMa.IsEnabled = true;
            CheckBoxMartesTar.IsEnabled = true;
        }

        private void CheckBoxMiercoles_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxMiercolesMa.IsEnabled = true;
            CheckBoxMiercolesTar.IsEnabled = true;
        }

        private void CheckBoxJueves_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxJuevesMa.IsEnabled = true;
            CheckBoxJuevesTar.IsEnabled = true;
        }

        private void CheckBoxViernes_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxViernesMa.IsEnabled = true;
            CheckBoxViernesTar.IsEnabled = true;
        }

        private void CheckBoxSabado_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxSabadoMa.IsEnabled = true;
            CheckBoxSabadoTar.IsEnabled = true;
        }

        private void CheckBoxDomingo_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxDomingoMa.IsEnabled = true;
            CheckBoxDomingoTar.IsEnabled = true;
        }

        private void CheckBoxDomingo_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxDomingoMa.IsEnabled = false;
            CheckBoxDomingoTar.IsEnabled = false;
            CheckBoxDomingoMa.IsChecked = false;
            CheckBoxDomingoTar.IsChecked = false;

        }

        private void CheckBoxSabado_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxSabadoMa.IsEnabled = false;
            CheckBoxSabadoTar.IsEnabled = false;
            CheckBoxSabadoMa.IsChecked = false;
            CheckBoxSabadoTar.IsChecked = false;
        }

        private void CheckBoxViernes_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxViernesMa.IsEnabled = false;
            CheckBoxViernesTar.IsEnabled = false;
            CheckBoxViernesMa.IsChecked = false;
            CheckBoxViernesTar.IsChecked = false;
        }

        private void CheckBoxJueves_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxJuevesMa.IsEnabled = false;
            CheckBoxJuevesTar.IsEnabled = false;
            CheckBoxJuevesMa.IsChecked = false;
            CheckBoxJuevesTar.IsChecked = false;
        }

        private void CheckBoxMiercoles_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxMiercolesMa.IsEnabled = false;
            CheckBoxMiercolesTar.IsEnabled = false;
            CheckBoxMiercolesMa.IsChecked = false;
            CheckBoxMiercolesTar.IsChecked = false;
        }

        private void CheckBoxMartes_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxMartesMa.IsEnabled = false;
            CheckBoxMartesTar.IsEnabled = false;
            CheckBoxMartesMa.IsChecked = false;
            CheckBoxMartesTar.IsChecked = false;
        }

        private void CheckBoxLunes_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBoxLunesMa.IsEnabled = false;
            CheckBoxLunesTar.IsEnabled = false;
            CheckBoxLunesMa.IsChecked = false;
            CheckBoxLunesTar.IsChecked = false;
        }
    }
}
