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
using System.Data.OleDb;
using Oracle.DataAccess;

namespace ProyectoIPO2020_2021
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    /// 



    public partial class Login : Window
    {
        private Aplicacion ventanaApp = new Aplicacion();

        private BitmapImage imagCheck = new BitmapImage(new Uri("/Images/Check.jpg", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/Images/Cross.jpg", UriKind.Relative));
        private BitmapImage imagOriginal = new BitmapImage(new Uri("/Images/icono.png", UriKind.Relative));
        private BitmapImage imagRollOver = new BitmapImage(new Uri("/Images/icono2.png", UriKind.Relative));
        
        public static string correo = "";
        public static string contra = "";
        private string correo1 = Aplicacion.usuario1.correo;
        private string contra1 = Aplicacion.usuario1.contraseña;
        private string correo2 = Aplicacion.usuario2.correo;
        private string contra2 = Aplicacion.usuario2.contraseña;
        private string correo3 = Aplicacion.usuario3.correo;
        private string contra3 = Aplicacion.usuario3.contraseña;
        


        public Login()
        {
            
            InitializeComponent();
           
            
        }

        public string establecerCorreo()
        {
           
            if (txtUsuario.Text == correo1)
            {
                correo = txtUsuario.Text;
            }
            if(txtUsuario.Text == correo2)
            {
                correo = correo2;
            }
            if(txtUsuario.Text == correo3)
            {
                correo = correo3;
            }
            return correo;
        }

        private string establecerContra()
        {
            if (passContra.Password == contra1)
            {
                contra = contra1;
            }
            if (passContra.Password == contra2)
            {
                contra = contra2;
            }
            if (passContra.Password == contra2)
            {
                contra = contra3;
            }
            return contra;
        }


        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            txtUsuario.IsEnabled = true;
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {    
                //
                if (!string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(passContra.Password) && ComprobarEntrada(txtUsuario.Text, establecerCorreo(), txtUsuario, imgCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContra.IsEnabled = true;
                    passContra.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }

        }
        private void passContra_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Return)
                {

                    if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(passContra.Password) && ComprobarEntrada(txtUsuario.Text, establecerCorreo(), txtUsuario, imgCheckUsuario) && ComprobarEntrada(passContra.Password, establecerContra(), passContra, imgCheckContrasena))
                    {
                        ventanaApp.Show();
                    }
                }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            if (ComprobarEntrada(txtUsuario.Text, establecerCorreo(), txtUsuario, imgCheckUsuario) && (ComprobarEntrada(passContra.Password, establecerContra(), passContra, imgCheckContrasena)))
            {
                ventanaApp.Show();
            }
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("¡Nos vemos! Hasta otra.", "Despedida");
        }

        private bool ComprobarEntrada(string valorIntroducido, string valorValido, Control componenteEntrada, Image imagenFeedBack)
        {
            bool valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde y fondo en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightSalmon;

                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void imgAvatar_MouseEnter(object sender, MouseEventArgs e)
        {
            imgAvatar.Source = imagRollOver;
           
        }
        private void imgAvatar_MouseLeave(object sender, MouseEventArgs e)
        {
            imgAvatar.Source = imagOriginal;
        }
            
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
           VentanaPrincipal.Close();

        }

        private void ContraseñaOlvidada_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Si desea recuperar la contraseña mande un correo electrónico a: " +
                "soporte.tecnico@prot3ctora.es indicando: \nSu correo electrónico, DNI y número de teléfono.\n" +
                "Estableciendo como asunto HE OLVIDADO MI CONTRASEÑA. Se pondrán en contacto con usted lo antes posible.", 
                "Cerrar");
            //ventanaAyudaContraseña.Show();
        }
    }
}
