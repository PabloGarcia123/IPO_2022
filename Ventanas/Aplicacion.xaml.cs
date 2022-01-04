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
using ProyectoIPO2020_2021.Clases;

namespace ProyectoIPO2020_2021
{
    /// <summary>
    /// Lógica de interacción para Aplicacion.xaml
    /// </summary>
    public partial class Aplicacion : Window
    {
        
        private VentanaAyuda ventanaAyuda = new VentanaAyuda();
        private Apadrinado ventanaPadrinos = new Apadrinado();
        
        

        public Aplicacion()
        {
            
            InitializeComponent();
            //cargarInfo();
            /*
            txtblockDetUser.Text = usuario1.correo;
            imgPerfil.Source = usuario1.img;
            lblNombre.Content = usuario1.nombre;
            txtblockDni.Text = usuario1.dni;
            lblTlf.Content = usuario1.n_tlf;
            lblFecha.Content = usuario1.ult_acceso;
            */
 
        }
        /*private void cargarInfo()
        {
            if(Login.correo == usuario1.correo)
            {
                txtblockDetUser.Text = usuario1.correo;
                imgPerfil.Source = usuario1.img;
                lblNombre.Content = usuario1.nombre;
                txtblockDni.Text = usuario1.dni;
                lblTlf.Content = usuario1.n_tlf;
                lblFecha.Content = usuario1.ult_acceso;
            }
            if (Login.correo == usuario2.correo)
            {
                txtblockDetUser.Text = usuario2.correo;
                imgPerfil.Source = usuario2.img;
                lblNombre.Content = usuario2.nombre;
                txtblockDni.Text = usuario2.dni;
                lblTlf.Content = usuario2.n_tlf;
                lblFecha.Content = usuario2.ult_acceso;
            }
            if (Login.correo == usuario3.correo)
            {
                txtblockDetUser.Text = usuario3.correo;
                imgPerfil.Source = usuario3.img;
                lblNombre.Content = usuario3.nombre;
                txtblockDni.Text = usuario3.dni;
                lblTlf.Content = usuario3.n_tlf;
                lblFecha.Content = usuario3.ult_acceso;
            }
        }*/

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
            if (string.IsNullOrEmpty(txtboxNombrePerro.Text))
            {
                txtboxNombrePerro.BorderBrush = Brushes.Red;
                txtboxNombrePerro.Background = Brushes.LightSalmon;
            }
            else if (!(radiobMacho.IsChecked.Value))
            {
                if(!(radiobHembra.IsChecked.Value)){
                    MessageBox.Show("No ha definido el sexo del perro ", "SexoPerro");
                }
                
            }
            else if (string.IsNullOrEmpty(txtboxRazaPerro.Text))
            {
                txtboxRazaPerro.BorderBrush = Brushes.Red;
                txtboxRazaPerro.Background = Brushes.LightSalmon;
            }
            else if (string.IsNullOrEmpty(txtboxPesoPerro.Text))
            {
                txtboxPesoPerro.BorderBrush = Brushes.Red;
                txtboxPesoPerro.Background = Brushes.LightSalmon;
            }
            else if (string.IsNullOrEmpty(txtEdadPerro.Text))
            {
                txtEdadPerro.BorderBrush = Brushes.Red;
                txtEdadPerro.Background = Brushes.LightSalmon;
            }
            else if (string.IsNullOrEmpty(dateFechaPerro.Text))
            {
                dateFechaPerro.BorderBrush = Brushes.Red;
                dateFechaPerro.Background = Brushes.LightSalmon;
            }
            else if (string.IsNullOrEmpty(txtboxDescripcion.Text))
            {
                txtboxDescripcion.BorderBrush = Brushes.Red;
                txtboxDescripcion.Background = Brushes.LightSalmon;
            }
            else
            {
                string sexo_perro = obtenerSexoPerro();

                StreamWriter escribir = new StreamWriter("TablaPerros.txt");

                escribir.WriteLine("Nombre: " + txtboxNombrePerro.Text);
                escribir.WriteLine("Sexo: " + sexo_perro);
                escribir.WriteLine("Raza: " + txtboxRazaPerro.Text);
                escribir.WriteLine("Peso: " + txtboxPesoPerro.Text);
                escribir.WriteLine("Edad: " + txtEdadPerro.Text);
                escribir.WriteLine("Fecha de entrada: " + dateFechaPerro.Text);
                escribir.WriteLine("¿Apadrinado?: " + checkApadrinado.IsChecked);
                escribir.WriteLine("Descripción: " + txtboxDescripcion.Text);
                escribir.WriteLine("\n");
                escribir.Close();
                MessageBox.Show("El perro ha sido añadido ", "Perro");
            }
            
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            richPerros.Document.Blocks.Clear();
            StreamReader leer = new StreamReader("TablaPerros.txt");
            string linea;
            
            try
            {
                linea = leer.ReadLine();
                while (linea != null)
                {
                    richPerros.AppendText(linea + "\n");
                    linea = leer.ReadLine();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private string obtenerSexoPerro()
        {
            string sexo;
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

        private void txtboxNombreSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxApellidoSocio.Focus();
            }
        }

        private void txtboxApellidoSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxDNISocio.Focus();
            }
        }

        private void txtboxDNISocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxTelefonoSocio.Focus();
            }
        }

        private void txtboxTelefonoSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtCorreoElectronicoSocio.Focus();
            }
        }

        private void txtCorreoElectronicoSocio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtEntidadBancaria.Focus();
            }
        }

        private void txtEntidadBancaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN1.Focus();
            }
        }

        private void txtIBAN1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN2.Focus();
            }
        }

        private void txtIBAN2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN3.Focus();
            }
        }

        private void txtIBAN3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN4.Focus();
            }
        }

        private void txtIBAN4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN5.Focus();
            }
        }

        private void txtIBAN5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtIBAN6.Focus();
            }
        }

        private void txtIBAN6_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtCuantia.Focus();
            }
        }

        private void txtCuantia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cboxformPago.Focus();
            }
        }

        private void txtboxNombreVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxApellidoVoluntario.Focus();
            }
        }

        private void txtboxApellidoVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxDNIVoluntario.Focus();
            }
        }

        private void txtboxDNIVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxTelefonoVoluntario.Focus();
            }
        }

        private void txtboxTelefonoVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtCorreoElectronicoVoluntario.Focus();
            }
        }

        private void txtboxNombrePerro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                radiobMacho.Focus();
            }
        }

        private void radiobMacho_Checked(object sender, RoutedEventArgs e)
        {
            txtboxRazaPerro.Focus();   
        }

        private void radiobHembra_Checked(object sender, RoutedEventArgs e)
        {
            txtboxRazaPerro.Focus();
        }

        private void txtboxRazaPerro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtboxPesoPerro.Focus();
            }
        }

        private void txtboxPesoPerro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtEdadPerro.Focus();
            }
        }

        private void txtEdadPerro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                dateFechaPerro.Focus();
            }
        }

        private void checkApadrinado_Checked(object sender, RoutedEventArgs e)
        {
            txtboxDescripcion.Focus();
        }
    }
}
