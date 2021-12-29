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
        private AyudaContraseña ventanaAyudaContraseña = new AyudaContraseña();
        private String correo = "Mario.Torres@gmail.com";
        private String contra = "123";
        

        public Login()
        {
            InitializeComponent();
            
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            txtUsuario.IsEnabled = true;
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {    
                if (!String.IsNullOrEmpty(txtUsuario.Text) && String.IsNullOrEmpty(passContra.Password) && ComprobarEntrada(txtUsuario.Text, correo, txtUsuario, imgCheckUsuario))
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

                    if (!String.IsNullOrEmpty(txtUsuario.Text) && !String.IsNullOrEmpty(passContra.Password) && ComprobarEntrada(txtUsuario.Text, correo, txtUsuario, imgCheckUsuario) && ComprobarEntrada(passContra.Password, contra, passContra, imgCheckContrasena))
                    {
                        ventanaApp.Show();
                    }
                }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            if (ComprobarEntrada(txtUsuario.Text, correo,txtUsuario, imgCheckUsuario) && (ComprobarEntrada(passContra.Password, contra, passContra, imgCheckContrasena)))
            {
                ventanaApp.Show();
            }
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("¡Nos vemos! Hasta otra.", "Despedida");
        }

        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido, Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
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

            MessageBox.Show("Si desea recuperar la contraseña mande un correo electrónico a: &#xA;                      soporte.tecnico@prot3ctora.es&#xA;indicando: Su correo electrónico, DNI y número de teléfono.&#xA;Estableciendo como asunto HE OLVIDADO MI CONTRASEÑA.&#xA;Se pondrán en contacto con usted lo antes posible.", "Cerrar");
            //ventanaAyudaContraseña.Show();
        }
    }
}
