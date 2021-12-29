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
    /// Lógica de interacción para Aplicacion.xaml
    /// </summary>
    public partial class Aplicacion : Window
    {
        
        private VentanaAyuda ventanaAyuda = new VentanaAyuda();
        private Apadrinado ventanaPadrinos = new Apadrinado();
        

        private static BitmapImage imgUsuario1 = new BitmapImage(new Uri("/Images/Mike-Wazowski.jpg", UriKind.Relative));
        private static Usuario usuario1 = new Usuario("Mario Torres Toledano", "Mario.Torres@gmail.com", "05285136F", 688455782, DateTime.Now, imgUsuario1, "123");
        
        public static OleDbConnection conectar = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\05980124\\OneDrive\\Uni\\Vs2019Projects\\ProyectoIPO2020-2021\\ProyectoIPO2020-2021\\BasesDeDatos\\BBDDPerros.accdb");
        OleDbCommand comando = new OleDbCommand();
        
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
        private void btnCbPerfil_Click(object sender, RoutedEventArgs e)
        {
            
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
         
           
        }



        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
