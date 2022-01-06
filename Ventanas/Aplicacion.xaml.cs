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
using System.Windows.Media.Imaging;

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

            limpiarPerro();
            limpiarVoluntario();
            limpiarSocio();
            
            
 
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

        private void btnAñadirImagen_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    if(sender == btnAñadirImagenPerro)
                    {
                        imgPerro.Source = bitmap;
                    }
                    if (sender == btnAñadirImagenVoluntario)
                    {
                        imgVoluntario.Source = bitmap;
                    }
                    if (sender == btnAñadirImagenSocio)
                    {
                        imgSocio.Source = bitmap;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
           
        }
     
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnAñadirPerro)
            {
                if (string.IsNullOrEmpty(txtboxNombrePerro.Text))
                {
                    txtboxNombrePerro.BorderBrush = Brushes.Red;
                    txtboxNombrePerro.Background = Brushes.LightSalmon;
                }
                else if (!(radiobMacho.IsChecked.Value || radiobHembra.IsChecked.Value))
                {
                    MessageBox.Show("No ha definido el sexo del perro ", "SexoPerro");
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
                else if (imgPerro.Source == null)
                {
                    bordeImagenPerro.BorderBrush = Brushes.Red;
                    bordeImagenPerro.Background = Brushes.LightSalmon;
                }

                else
                {

                    Perro perro = new Perro(txtboxNombrePerro.Text, obtenerSexoPerro(), txtboxRazaPerro.Text, txtboxPesoPerro.Text, txtEdadPerro.Text, dateFechaPerro.Text, (bool)checkApadrinado.IsChecked, txtboxDescripcion.Text, imgPerro.Source);
                    dataGridPerros.Items.Add(perro);
                    limpiarPerro();
                }
            }
            else if(sender == btnAñadirVoluntario)
            {
                if (string.IsNullOrEmpty(txtboxNombreVoluntario.Text))
                {
                    txtboxNombreVoluntario.BorderBrush = Brushes.Red;
                    txtboxNombreVoluntario.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxApellidoVoluntario.Text))
                {
                    txtboxApellidoVoluntario.BorderBrush = Brushes.Red;
                    txtboxApellidoVoluntario.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxDNIVoluntario.Text))
                {
                    txtboxDNIVoluntario.BorderBrush = Brushes.Red;
                    txtboxDNIVoluntario.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxTelefonoVoluntario.Text))
                {
                    txtboxTelefonoVoluntario.BorderBrush = Brushes.Red;
                    txtboxTelefonoVoluntario.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtCorreoElectronicoVoluntario.Text))
                {
                    txtCorreoElectronicoVoluntario.BorderBrush = Brushes.Red;
                    txtCorreoElectronicoVoluntario.Background = Brushes.LightSalmon;
                }
                
                else if (imgVoluntario.Source == null)
                {
                    bordeImgVoluntario.BorderBrush = Brushes.Red;
                    bordeImgVoluntario.Background = Brushes.LightSalmon;
                }

                else
                {

                    Voluntario voluntario = new Voluntario(txtboxNombreVoluntario.Text, txtboxApellidoVoluntario.Text, txtboxDNIVoluntario.Text, int.Parse(txtboxTelefonoVoluntario.Text), txtCorreoElectronicoVoluntario.Text, (bool)checkConocimientosVeterinarios.IsChecked, "hola", imgVoluntario.Source);
                    dataGridVoluntarios.Items.Add(voluntario);
                    limpiarVoluntario();
                }
            }
            else if (sender == btnAñadirSocio)
            {
                if (string.IsNullOrEmpty(txtboxNombreSocio.Text))
                {
                    txtboxNombreSocio.BorderBrush = Brushes.Red;
                    txtboxNombreSocio.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxApellidoSocio.Text))
                {
                    txtboxApellidoSocio.BorderBrush = Brushes.Red;
                    txtboxApellidoSocio.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxDNISocio.Text))
                {
                    txtboxDNISocio.BorderBrush = Brushes.Red;
                    txtboxDNISocio.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtboxTelefonoSocio.Text))
                {
                    txtboxTelefonoSocio.BorderBrush = Brushes.Red;
                    txtboxTelefonoSocio.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtCorreoElectronicoSocio.Text))
                {
                    txtCorreoElectronicoSocio.BorderBrush = Brushes.Red;
                    txtCorreoElectronicoSocio.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtEntidadBancaria.Text))
                {
                    txtEntidadBancaria.BorderBrush = Brushes.Red;
                    txtEntidadBancaria.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN1.Text))
                {
                    txtIBAN1.BorderBrush = Brushes.Red;
                    txtIBAN1.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN2.Text))
                {
                    txtIBAN2.BorderBrush = Brushes.Red;
                    txtIBAN2.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN3.Text))
                {
                    txtIBAN3.BorderBrush = Brushes.Red;
                    txtIBAN3.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN4.Text))
                {
                    txtIBAN4.BorderBrush = Brushes.Red;
                    txtIBAN4.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN5.Text))
                {
                    txtIBAN5.BorderBrush = Brushes.Red;
                    txtIBAN5.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtIBAN6.Text))
                {
                    txtIBAN6.BorderBrush = Brushes.Red;
                    txtIBAN6.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(txtCuantia.Text))
                {
                    txtCuantia.BorderBrush = Brushes.Red;
                    txtCuantia.Background = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(cboxformPago.Text))
                {
                    MessageBox.Show("No ha definido el mñetodo de pago ", "Método de pago");
                }
                else if (imgSocio.Source == null)
                {
                    bordeImgSocio.BorderBrush = Brushes.Red;
                    bordeImgSocio.Background = Brushes.LightSalmon;
                }

                else
                {

                    Socio socio = new Socio(txtboxNombreSocio.Text, txtboxApellidoSocio.Text, txtboxDNISocio.Text, int.Parse(txtboxTelefonoSocio.Text), txtCorreoElectronicoSocio.Text, txtEntidadBancaria.Text, int.Parse(txtIBAN1.Text), int.Parse(txtIBAN2.Text), int.Parse(txtIBAN3.Text), int.Parse(txtIBAN4.Text), int.Parse(txtIBAN5.Text), int.Parse(txtIBAN6.Text), int.Parse(txtCuantia.Text),cboxformPago.Text, imgSocio.Source);
                    dataGridSocio.Items.Add(socio);
                    limpiarSocio();
                }
            }



        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            //dataGridPerros.ClearDetailsVisibilityForItem();
            StreamReader leer = new StreamReader("TablaPerros.txt");
            string linea;
            
            try
            {
                linea = leer.ReadLine();
                while (linea != null)
                {
                    //dataGridPerros.Items.Add();
                    linea = leer.ReadLine();

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            dataGridPerros.Items.RemoveAt(dataGridPerros.SelectedIndex);
            btnBorrarPerro.IsEnabled = false;
        }

        private void limpiarPerro()
        {
            //limpia perro
            btnBorrarPerro.IsEnabled = false;
            btnEditarPerro.IsEnabled = false;
            txtboxNombrePerro.Text = "";
            radiobHembra.IsChecked = false;
            radiobHembra.IsChecked = false;
            txtboxRazaPerro.Text = "";
            txtboxPesoPerro.Text = "";
            txtEdadPerro.Text = "";
            dateFechaPerro.SelectedDate = null;
            checkApadrinado.IsChecked = false;
            txtboxDescripcion.Text = "";
            txtboxNombrePerro.BorderBrush = Brushes.Black;
            txtboxNombrePerro.Background = Brushes.White;
            txtboxRazaPerro.BorderBrush = Brushes.Black;
            txtboxRazaPerro.Background = Brushes.White;
            txtboxPesoPerro.BorderBrush = Brushes.Black;
            txtboxPesoPerro.Background = Brushes.White;
            txtEdadPerro.BorderBrush = Brushes.Black;
            txtEdadPerro.Background = Brushes.White;
            dateFechaPerro.BorderBrush = Brushes.Black;
            dateFechaPerro.Background = Brushes.White;
            txtboxDescripcion.BorderBrush = Brushes.Black;
            txtboxDescripcion.Background = Brushes.White;
            bordeImagenPerro.BorderBrush = Brushes.Black;
            bordeImagenPerro.Background = Brushes.White;
            imgPerro.Source = null;
        }

        private void limpiarVoluntario()
        {
            //limpiar voluntario
            btnBorrarVoluntario.IsEnabled = false;
            btnEditarVoluntario.IsEnabled = false;
            txtboxNombreVoluntario.Text = "";
            txtboxApellidoVoluntario.Text = "";
            txtboxDNIVoluntario.Text = "";
            txtboxTelefonoVoluntario.Text = "";
            txtCorreoElectronicoVoluntario.Text = "";
            CheckBoxLunes.IsChecked = false;
            CheckBoxMartes.IsChecked = false;
            CheckBoxMiercoles.IsChecked = false;
            CheckBoxJueves.IsChecked = false;
            CheckBoxViernes.IsChecked = false;
            CheckBoxSabado.IsChecked = false;
            CheckBoxDomingo.IsChecked = false;
            txtboxNombreVoluntario.BorderBrush = Brushes.Black;
            txtboxNombreVoluntario.Background = Brushes.White;
            txtboxApellidoVoluntario.BorderBrush = Brushes.Black;
            txtboxApellidoVoluntario.Background = Brushes.White;
            txtboxDNIVoluntario.BorderBrush = Brushes.Black;
            txtboxDNIVoluntario.Background = Brushes.White;
            txtboxTelefonoVoluntario.BorderBrush = Brushes.Black;
            txtboxTelefonoVoluntario.Background = Brushes.White;
            txtCorreoElectronicoVoluntario.BorderBrush = Brushes.Black;
            txtCorreoElectronicoVoluntario.Background = Brushes.White;
            bordeImgVoluntario.BorderBrush = Brushes.Black;
            bordeImgVoluntario.Background = Brushes.White;
            imgVoluntario.Source = null;
        }

        private void limpiarSocio()
        {
            //limpiar socio
            btnBorrarSocio.IsEnabled = false;
            btnEditarSocio.IsEnabled = false;
            txtboxNombreSocio.Text = "";
            txtboxApellidoSocio.Text = "";
            txtboxDNISocio.Text = "";
            txtboxTelefonoSocio.Text = "";
            txtCorreoElectronicoSocio.Text = "";
            txtEntidadBancaria.Text = "";
            txtIBAN1.Text = "";
            txtIBAN2.Text = "";
            txtIBAN3.Text = "";
            txtIBAN4.Text = "";
            txtIBAN5.Text = "";
            txtIBAN6.Text = "";
            txtCuantia.Text = "";
            cboxformPago.Text = "";

            txtboxNombreSocio.BorderBrush = Brushes.Black;
            txtboxNombreSocio.Background = Brushes.White;
            txtboxApellidoSocio.BorderBrush = Brushes.Black;
            txtboxApellidoSocio.Background = Brushes.White;
            txtboxDNISocio.BorderBrush = Brushes.Black;
            txtboxDNISocio.Background = Brushes.White;
            txtboxTelefonoSocio.BorderBrush = Brushes.Black;
            txtboxTelefonoSocio.Background = Brushes.White;
            txtCorreoElectronicoSocio.BorderBrush = Brushes.Black;
            txtCorreoElectronicoSocio.Background = Brushes.White;
            txtEntidadBancaria.BorderBrush = Brushes.Black;
            txtEntidadBancaria.Background = Brushes.White;
            txtIBAN1.BorderBrush = Brushes.Black;
            txtIBAN1.Background = Brushes.White;
            txtIBAN2.BorderBrush = Brushes.Black;
            txtIBAN2.Background = Brushes.White;
            txtIBAN3.BorderBrush = Brushes.Black;
            txtIBAN3.Background = Brushes.White;
            txtIBAN4.BorderBrush = Brushes.Black;
            txtIBAN4.Background = Brushes.White;
            txtIBAN5.BorderBrush = Brushes.Black;
            txtIBAN5.Background = Brushes.White;
            txtIBAN6.BorderBrush = Brushes.Black;
            txtIBAN6.Background = Brushes.White;
            txtCuantia.BorderBrush = Brushes.Black;
            txtCuantia.Background = Brushes.White;
            bordeImgSocio.BorderBrush = Brushes.Black;
            bordeImgSocio.Background = Brushes.White;
            imgSocio.Source = null;
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


        //Luego sigo yo con este metodo, es para seleccionar las filas y que se muestre en los txtbox 
        private void dataGridPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBorrarPerro.IsEnabled = true;
            btnEditarPerro.IsEnabled = true;
            
            //txtboxNombrePerro.Text = Convert.ToString(dataGridPerros.SelectedItem);
        }

        
    }
}
