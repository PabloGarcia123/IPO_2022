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

        private static BitmapImage imgPadrino1 = new BitmapImage(new Uri("/Images/George.png", UriKind.Relative));
        private static BitmapImage imgPadrino2 = new BitmapImage(new Uri("/Images/Roz.png", UriKind.Relative));
        private static BitmapImage imgPadrino3 = new BitmapImage(new Uri("/Images/Henry.png", UriKind.Relative));



        public Aplicacion()
        {

            InitializeComponent();

            limpiarPerro();
            limpiarVoluntario();
            limpiarSocio();



        }

        public void cargarPadrinos(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(cboxPadrino.SelectedItem.ToString());


            if (cboxPadrino.SelectedIndex == 0)
            {

                Padrino padrino1 = new Padrino("Lorenzo", "Galván Moreno", "05980126D", "Lorenzo.Galvan@gmail.com", 664231235, 50, "Efectivo", 01289193000244163980, DateTime.Now, imgPadrino1);
                ventanaPadrinos.txtblockNombre.Text = padrino1.nombre;
                ventanaPadrinos.txtblockApellido.Text = padrino1.apellido;
                ventanaPadrinos.txtblockDNI.Text = padrino1.dni;
                ventanaPadrinos.txtblockCorreo.Text = padrino1.correo;
                ventanaPadrinos.txtblockNtlf.Text = padrino1.n_tlf.ToString();
                ventanaPadrinos.txtblockNCuenta.Text = padrino1.n_cuenta.ToString();
                ventanaPadrinos.txtblockFormapago.Text = padrino1.forma_pago;
                ventanaPadrinos.txtblockFechaapa.Text = padrino1.fecha_apadrinamiento.ToString();
                ventanaPadrinos.txtblockAportacion.Text = padrino1.aportacion.ToString() + "€";
                ventanaPadrinos.imgPerfil.Source = padrino1.img;
            }
            else if (cboxPadrino.SelectedIndex == 1)
            {

                Padrino padrino2 = new Padrino("Sheila", "Soria Pozo", "05986526D", "Sheila.Soria@gmail.com", 652345633, 100, "Transferencia Bancaria", 0002252228352538144762, DateTime.Now, imgPadrino2);
                ventanaPadrinos.txtblockNombre.Text = padrino2.nombre;
                ventanaPadrinos.txtblockApellido.Text = padrino2.apellido;
                ventanaPadrinos.txtblockDNI.Text = padrino2.dni;
                ventanaPadrinos.txtblockCorreo.Text = padrino2.correo;
                ventanaPadrinos.txtblockNtlf.Text = padrino2.n_tlf.ToString();
                ventanaPadrinos.txtblockNCuenta.Text = padrino2.n_cuenta.ToString();
                ventanaPadrinos.txtblockFormapago.Text = padrino2.forma_pago;
                ventanaPadrinos.txtblockFechaapa.Text = padrino2.fecha_apadrinamiento.ToString();
                ventanaPadrinos.txtblockAportacion.Text = padrino2.aportacion.ToString() + "€";
                ventanaPadrinos.imgPerfil.Source = padrino2.img;
            }
            else if (cboxPadrino.SelectedIndex == 2)
            {
                Padrino padrino3 = new Padrino("Sergio", "Mateu-Belmonte", "05123126D", "Sergio.Mateu@gmail.com", 678453456, 85, "Bizum", 0002252228456784344762, DateTime.Now, imgPadrino3);
                ventanaPadrinos.txtblockNombre.Text = padrino3.nombre;
                ventanaPadrinos.txtblockApellido.Text = padrino3.apellido;
                ventanaPadrinos.txtblockDNI.Text = padrino3.dni;
                ventanaPadrinos.txtblockCorreo.Text = padrino3.correo;
                ventanaPadrinos.txtblockNtlf.Text = padrino3.n_tlf.ToString();
                ventanaPadrinos.txtblockNCuenta.Text = padrino3.n_cuenta.ToString();
                ventanaPadrinos.txtblockFormapago.Text = padrino3.forma_pago;
                ventanaPadrinos.txtblockFechaapa.Text = padrino3.fecha_apadrinamiento.ToString();
                ventanaPadrinos.txtblockAportacion.Text = padrino3.aportacion.ToString() + "€";
                ventanaPadrinos.imgPerfil.Source = padrino3.img;
            }
        }

        private string obtenerPadrino()
        {
            string padrino = "";
            if (checkApadrinado.IsChecked == false)
            {
                padrino = "No hay";
            }
            else
            {
                padrino = cboxPadrino.Text;
            }
            return padrino;
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            ventanaAyuda.Show();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        /*
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
       */
        private void btnConsultaApadrinado_Click(object sender, RoutedEventArgs e)
        {
            cargarPadrinos(sender, e);
            ventanaPadrinos.Show();
            btnConsultaApadrinado.IsEnabled = false;
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
                    if (sender == btnAñadirImagenPerro)
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
        /*
        private void Save(object sender, RoutedEventArgs e) 
        {
            SaveFileDialog datos = new SaveFileDialog();
            Console.WriteLine(datos);
            datos.Filter = "Texto(*.txt) | *.txt";

            if (datos.ShowDialog() == true)
            {
                string archivo = datos.FileName;
                StringBuilder strB = new StringBuilder();
                if (sender == btnAñadirPerro)
                {
                    for (int i = 0; i < dataGridPerros.Items.Count; i++)
                    {
                        Perro line = (Perro)dataGridPerros.Items[i];
                        strB.AppendLine(line.nombre.ToString() + ", " + line.sexo.ToString() + ", " + line.raza.ToString() + ", " + line.peso.ToString() + ", " + line.edad.ToString() + ", " + line.fecha_entrada.ToString() + ", " + line.apadrinado.ToString() + ", " + line.n_padrino.ToString() + ", " + line.descripcion.ToString() + ",\n" + line.img.ToString());
                    }
                }
                if (sender == btnAñadirVoluntario)
                {
                    for (int i = 0; i < dataGridVoluntarios.Items.Count; i++)
                    {
                        Voluntario line = (Voluntario)dataGridVoluntarios.Items[i];
                        strB.AppendLine(line.nombre.ToString() + ", " + line.apellido.ToString() + ", " + line.dni.ToString() + ", " + line.n_tlf.ToString() + ", " + line.correo.ToString() + ", " + line.conocimientos.ToString() + ", " + line.disponibilidad.ToString() + ",\n" + line.img.ToString());
                    }
                }
                if (sender == btnAñadirSocio)
                {
                    for (int i = 0; i < dataGridSocio.Items.Count; i++)
                    {
                        Socio line = (Socio)dataGridSocio.Items[i];
                        strB.AppendLine(line.nombre.ToString() + ", " + line.apellido.ToString() + ", " + line.dni.ToString() + ", " + line.n_tlf.ToString() + ", " + line.correo.ToString() + ", " + line.ent_bancaria.ToString() + ", " + line.IBAN1.ToString() + ", " + line.IBAN2.ToString() + ", " + line.IBAN3.ToString()+", " + line.IBAN4.ToString() + ", " + line.IBAN5.ToString() + ", " + line.IBAN6.ToString() + ", " + line.cuantia.ToString() + ", " + line.metodo_pago.ToString() + ",\n" + line.img.ToString());
                    }
                }
                File.WriteAllText(archivo, strB.ToString());
            }
        }
        */
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
                else if (string.IsNullOrEmpty(cboxPadrino.Text) && (checkApadrinado.IsChecked == true))
                {
                    MessageBox.Show("No ha definido el padrino ", "Padrino");
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

                    Perro perro = new Perro(txtboxNombrePerro.Text, obtenerSexoPerro(), txtboxRazaPerro.Text, double.Parse(txtboxPesoPerro.Text), int.Parse(txtEdadPerro.Text), dateFechaPerro.Text, (bool)checkApadrinado.IsChecked, cboxPadrino.Text, txtboxDescripcion.Text, imgPerro.Source);
                    dataGridPerros.Items.Add(perro);
                    limpiarPerro();
                    //Save(sender, e);


                }
            }
            else if (sender == btnAñadirVoluntario)
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

                    Voluntario voluntario = new Voluntario(txtboxNombreVoluntario.Text, txtboxApellidoVoluntario.Text, txtboxDNIVoluntario.Text, int.Parse(txtboxTelefonoVoluntario.Text), txtCorreoElectronicoVoluntario.Text, (bool)checkConocimientosVeterinarios.IsChecked, obtenerDisponibilidad(), imgVoluntario.Source);
                    dataGridVoluntarios.Items.Add(voluntario);
                    limpiarVoluntario();
                    //Save(sender, e);
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
                    MessageBox.Show("No ha definido el metodo de pago ", "Método de pago");
                }
                else if (imgSocio.Source == null)
                {
                    bordeImgSocio.BorderBrush = Brushes.Red;
                    bordeImgSocio.Background = Brushes.LightSalmon;
                }

                else
                {

                    Socio socio = new Socio(txtboxNombreSocio.Text, txtboxApellidoSocio.Text, txtboxDNISocio.Text, int.Parse(txtboxTelefonoSocio.Text), txtCorreoElectronicoSocio.Text, txtEntidadBancaria.Text, txtIBAN1.Text, int.Parse(txtIBAN2.Text), int.Parse(txtIBAN3.Text), int.Parse(txtIBAN4.Text), int.Parse(txtIBAN5.Text), int.Parse(txtIBAN6.Text), int.Parse(txtCuantia.Text), cboxformPago.Text, imgSocio.Source);
                    dataGridSocio.Items.Add(socio);
                    limpiarSocio();
                    //Save(sender, e);
                }
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnListarPerro)
            {
                BitmapImage imgperro1 = new BitmapImage(new Uri("/Images/James.png", UriKind.Relative));
                BitmapImage imgperro2 = new BitmapImage(new Uri("/Images/billy.jpg", UriKind.Relative));
                BitmapImage imgperro3 = new BitmapImage(new Uri("/Images/cutter_.jpeg", UriKind.Relative));
                limpiarPerro();
                Perro perro1 = new Perro("Canela", "Hembra", "Podenco Andaluz", 35, 2, "10/01/2022", true, "Lorenzo", "Es una perra muy activa, le gusta mucho jugar", imgperro1);
                Perro perro2 = new Perro("Nera", "Hembra", "Perro de aguas", 32, 4, "10/01/2022", true, "Sheila", "Es una perra muy muy tranquila", imgperro2);
                Perro perro3 = new Perro("Karl", "Macho", "Labrador", 49, 2, "10/01/2022", false, "No hay", "Es una perro muy cariñoso", imgperro3);
                dataGridPerros.Items.Add(perro1);
                dataGridPerros.Items.Add(perro2);
                dataGridPerros.Items.Add(perro3);
                btnListarPerro.IsEnabled = false;
                limpiarPerro();
            }
            if (sender == btnListarVoluntario)
            {
                BitmapImage imgvoluntario1 = new BitmapImage(new Uri("/Images/terry.png", UriKind.Relative));
                BitmapImage imgvoluntario2 = new BitmapImage(new Uri("/Images/Juan.jpg", UriKind.Relative));
                BitmapImage imgvoluntario3 = new BitmapImage(new Uri("/Images/CeliaMae.png", UriKind.Relative));
                limpiarVoluntario();
                Voluntario voluntario1 = new Voluntario("Juan", "López Garcia", "71370261R", 626808425, "juangl@gmail.com", true, "Lunes: Mañana; Martes: Tarde; Jueves: Mañana; Tarde;", imgvoluntario1);
                Voluntario voluntario2 = new Voluntario("Sofia", "Gómez Mancebo", "09877890L", 616509416, "sofia_morenita@gmail.com", true, "Viernes: Mañana; Tarde; Sábado: Tarde; Domingo: Mañana; Tarde;", imgvoluntario2);
                Voluntario voluntario3 = new Voluntario("Patricia", "Vilchez Megia", "55443322S", 628164652, "patrilaaspi@gmail.com", true, "Lunes: Tarde; Martes: Tarde; Miercoles: Tarde; Jueves: Tarde; Viernes: Tarde; Sábado: Tarde; Domingo: Tarde;", imgvoluntario3);
                dataGridVoluntarios.Items.Add(voluntario1);
                dataGridVoluntarios.Items.Add(voluntario2);
                dataGridVoluntarios.Items.Add(voluntario3);
                btnListarVoluntario.IsEnabled = false;
                limpiarVoluntario();

            }
            if (sender == btnListarSocio)
            {
                BitmapImage imgsocio1 = new BitmapImage(new Uri("/Images/Tylor.jpg", UriKind.Relative));
                BitmapImage imgsocio2 = new BitmapImage(new Uri("/Images/Sargenta.png", UriKind.Relative));
                BitmapImage imgsocio3 = new BitmapImage(new Uri("/Images/Ranall.jpg", UriKind.Relative));
                limpiarSocio();
                Socio socio1 = new Socio("Irene", "Peláez Sánchez", "12345678Q", 926356563, "irenitabahita@gmail.com", "Globalcaja", "ES70", 4444, 2232, 3323, 9878, 2525, 40.8, "Paypal", imgsocio1);
                Socio socio2 = new Socio("Ariadna", "Peláez Sánchez", "19385668E", 926356563, "ariadnaofical@gmail.com", "Santander", "ES50", 2144, 2442, 1729, 1444, 3329, 1200.5, "Paypal", imgsocio2);
                Socio socio3 = new Socio("Rocio", "Arias Moraleda", "75432211Z", 636589926, "rocioCanarias@gmail.com", "Unicaja", "ES50", 7465, 1987, 5600, 3012, 5832, 50, "Bizum", imgsocio3);
                dataGridSocio.Items.Add(socio1);
                dataGridSocio.Items.Add(socio2);
                dataGridSocio.Items.Add(socio3);
                btnListarSocio.IsEnabled = false;
                limpiarSocio();
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnBorrarPerro)
            {
                dataGridPerros.Items.Remove(dataGridPerros.SelectedItem);
                btnBorrarPerro.IsEnabled = false;
                limpiarPerro();
            }
            else if (sender == btnBorrarVoluntario)
            {
                dataGridVoluntarios.Items.RemoveAt(dataGridVoluntarios.SelectedIndex);
                btnBorrarPerro.IsEnabled = false;
                limpiarVoluntario();
            }
            else if (sender == btnBorrarSocio)
            {
                dataGridSocio.Items.RemoveAt(dataGridSocio.SelectedIndex);
                btnBorrarSocio.IsEnabled = false;
                limpiarSocio();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnEditarPerro)
            {
                Perro perro = new Perro();
                Perro line = (Perro)dataGridPerros.SelectedItem;

                perro.nombre = txtboxNombrePerro.Text;
                perro.sexo = obtenerSexoPerro();
                perro.raza = txtboxRazaPerro.Text;
                perro.peso = double.Parse(txtboxPesoPerro.Text);
                perro.edad = int.Parse(txtEdadPerro.Text);
                perro.fecha_entrada = dateFechaPerro.Text;
                perro.apadrinado = (bool)checkApadrinado.IsChecked;
                perro.n_padrino = obtenerPadrino();
                perro.descripcion = txtboxDescripcion.Text;
                perro.img = imgPerro.Source;

                if (perro != line)
                {
                    dataGridPerros.Items.RemoveAt(dataGridPerros.SelectedIndex);
                    dataGridPerros.Items.Add(perro);
                }

                limpiarPerro();
            }

            if (sender == btnEditarVoluntario)
            {
                Voluntario voluntario = new Voluntario();
                Voluntario line = (Voluntario)dataGridVoluntarios.SelectedItem;

                voluntario.nombre = txtboxNombreVoluntario.Text;
                voluntario.apellido = txtboxApellidoVoluntario.Text;
                voluntario.dni = txtboxDNIVoluntario.Text;
                voluntario.n_tlf = int.Parse(txtboxTelefonoVoluntario.Text);
                voluntario.correo = txtCorreoElectronicoVoluntario.Text;
                voluntario.conocimientos = (bool)checkConocimientosVeterinarios.IsChecked;
                voluntario.disponibilidad = obtenerDisponibilidad();
                voluntario.img = imgVoluntario.Source;

                if (voluntario != line)
                {
                    dataGridVoluntarios.Items.RemoveAt(dataGridVoluntarios.SelectedIndex);
                    dataGridVoluntarios.Items.Add(voluntario);
                }
                limpiarVoluntario();
            }

            if (sender == btnEditarSocio)
            {
                Socio socio = new Socio();
                Socio line = (Socio)dataGridSocio.SelectedItem;

                socio.nombre = txtboxNombreSocio.Text;
                socio.apellido = txtboxApellidoSocio.Text;
                socio.dni = txtboxDNISocio.Text;
                socio.n_tlf = int.Parse(txtboxTelefonoSocio.Text);
                socio.correo = txtCorreoElectronicoSocio.Text;
                socio.ent_bancaria = txtEntidadBancaria.Text;
                socio.IBAN1 = txtIBAN1.Text;
                socio.IBAN2 = int.Parse(txtIBAN2.Text);
                socio.IBAN3 = int.Parse(txtIBAN3.Text);
                socio.IBAN4 = int.Parse(txtIBAN4.Text);
                socio.IBAN5 = int.Parse(txtIBAN5.Text);
                socio.IBAN6 = int.Parse(txtIBAN6.Text);
                socio.cuantia = double.Parse(txtCuantia.Text);
                socio.metodo_pago = cboxformPago.Text;
                socio.img = imgSocio.Source;

                if (socio != line)
                {
                    dataGridSocio.Items.RemoveAt(dataGridSocio.SelectedIndex);
                    dataGridSocio.Items.Add(socio);
                }
                limpiarSocio();
            }
        }

        private void dataGridPerros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == dataGridPerros && dataGridPerros.SelectedItem != null)
            {
                limpiarPerro();
                btnBorrarPerro.IsEnabled = true;
                btnEditarPerro.IsEnabled = true;

                Perro line = (Perro)dataGridPerros.SelectedItem;


                txtboxNombrePerro.Text = line.nombre.ToString();
                if (line.sexo.ToString() == "Macho")
                {
                    radiobMacho.IsChecked = true;
                }
                else
                {
                    radiobHembra.IsChecked = true;
                }
                txtboxRazaPerro.Text = line.raza.ToString();
                txtboxPesoPerro.Text = line.peso.ToString();
                txtEdadPerro.Text = line.edad.ToString();
                dateFechaPerro.Text = line.fecha_entrada.ToString();
                if (line.apadrinado.ToString() == "True")
                {
                    checkApadrinado.IsChecked = true;

                }
                cboxPadrino.Text = line.n_padrino.ToString();

                /*if(line.n_padrino.ToString() == "Lorenzo")
                {
                    cboxPadrinos.SelectedItem = 0;
                    Console.WriteLine(line.n_padrino.ToString());
                }
                if (line.n_padrino.ToString() == "Sheila")
                {
                    cboxPadrinos.SelectedItem = 1;
                }
                if (line.n_padrino.ToString() == "Sergio")
                {
                    cboxPadrinos.SelectedItem = 2;
                }*/

                txtboxDescripcion.Text = line.descripcion;
                imgPerro.Source = line.img;
            }
            if (sender == dataGridVoluntarios && dataGridVoluntarios.SelectedItem != null)
            {
                limpiarVoluntario();
                btnBorrarVoluntario.IsEnabled = true;
                btnEditarVoluntario.IsEnabled = true;

                Voluntario line = (Voluntario)dataGridVoluntarios.SelectedItem;

                txtboxNombreVoluntario.Text = line.nombre.ToString();
                txtboxApellidoVoluntario.Text = line.apellido.ToString();
                txtboxDNIVoluntario.Text = line.dni.ToString();
                txtboxTelefonoVoluntario.Text = line.n_tlf.ToString();
                txtCorreoElectronicoVoluntario.Text = line.correo.ToString();
                imgVoluntario.Source = line.img;
                if (line.conocimientos.ToString() == "True")
                {
                    checkConocimientosVeterinarios.IsChecked = true;
                }

                if (line.disponibilidad.ToString() == "True")
                {
                    CheckBoxLunes.IsChecked = true;
                }

                int i = 0;
                string disp = line.disponibilidad.ToString() + " fin";
                string[] palabras = disp.Split(' ');

                do
                {
                    if (palabras[i] == "Lunes:")
                    {
                        CheckBoxLunes.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxLunesMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxLunesTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Martes:")
                    {
                        CheckBoxMartes.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxMartesMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxMartesTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Miercoles:")
                    {
                        CheckBoxMiercoles.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxMiercolesMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxMiercolesTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Jueves:")
                    {
                        CheckBoxJueves.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxJuevesMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxJuevesTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Viernes:")
                    {
                        CheckBoxViernes.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxViernesMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxViernesTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Sábado:")
                    {
                        CheckBoxSabado.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxSabadoMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxSabadoTar.IsChecked = true;
                        i++;
                    }
                    ////////////////////////////////////////////////
                    if (palabras[i] == "Domingo:")
                    {
                        CheckBoxDomingo.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Mañana;")
                    {
                        CheckBoxDomingoMa.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "Tarde;")
                    {
                        CheckBoxDomingoTar.IsChecked = true;
                        i++;
                    }
                    if (palabras[i] == "fin")
                    {
                        i++;
                    }

                } while (i < palabras.Length);


            }

            if (sender == dataGridSocio && dataGridSocio.SelectedItem != null)
            {
                limpiarSocio();
                btnBorrarSocio.IsEnabled = true;
                btnEditarSocio.IsEnabled = true;

                Socio line = (Socio)dataGridSocio.SelectedItem;


                txtboxNombreSocio.Text = line.nombre.ToString();
                txtboxApellidoSocio.Text = line.apellido.ToString();
                txtboxDNISocio.Text = line.dni.ToString();
                txtboxTelefonoSocio.Text = line.n_tlf.ToString();
                txtCorreoElectronicoSocio.Text = line.correo.ToString();
                txtEntidadBancaria.Text = line.ent_bancaria;
                txtIBAN1.Text = line.IBAN1.ToString();
                txtIBAN2.Text = line.IBAN2.ToString();
                txtIBAN3.Text = line.IBAN3.ToString();
                txtIBAN4.Text = line.IBAN4.ToString();
                txtIBAN5.Text = line.IBAN5.ToString();
                txtIBAN6.Text = line.IBAN6.ToString();
                txtCuantia.Text = line.cuantia.ToString();
                cboxformPago.Text = line.metodo_pago.ToString();
                imgSocio.Source = line.img;
            }

        }

        private void limpiarPerro()
        {
            //limpia perro
            btnBorrarPerro.IsEnabled = false;
            btnEditarPerro.IsEnabled = false;
            txtboxNombrePerro.Text = "";
            radiobMacho.IsChecked = false;
            radiobHembra.IsChecked = false;
            txtboxRazaPerro.Text = "";
            //cboxPadrinos.Text = "";
            cboxPadrino.Text = "";
            txtboxPesoPerro.Text = "";
            txtEdadPerro.Text = "";
            btnConsultaApadrinado.IsEnabled = false;
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
            checkConocimientosVeterinarios.IsChecked = false;
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
            string sexo = "";
            if (radiobMacho.IsChecked == true)
            {
                sexo = (string)radiobMacho.Content;
            }
            if (radiobHembra.IsChecked == true)
            {
                sexo = (string)radiobHembra.Content;
            }
            return sexo;
        }

        private string obtenerDisponibilidad()
        {
            string disponibilidad = "";
            if (CheckBoxLunes.IsChecked == true)
            {
                disponibilidad = "Lunes:";
                if (CheckBoxLunesMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxLunesTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxMartes.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Martes:";
                if (CheckBoxMartesMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxMartesTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxMiercoles.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Miercoles:";
                if (CheckBoxMiercolesMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxMiercolesTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxJueves.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Jueves:";
                if (CheckBoxJuevesMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxJuevesTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxViernes.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Viernes:";
                if (CheckBoxViernesMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxViernesTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxSabado.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Sábado:";
                if (CheckBoxSabadoMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxSabadoTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            if (CheckBoxDomingo.IsChecked == true)
            {
                disponibilidad = disponibilidad + " Domingo:";
                if (CheckBoxDomingoMa.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Mañana;";
                }
                if (CheckBoxDomingoTar.IsChecked == true)
                {
                    disponibilidad = disponibilidad + " Tarde;";
                }

            }

            return disponibilidad;
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

        private void VentanaApp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;


        }

        private void btnCbPerfil_Click(object sender, RoutedEventArgs e)
        {
            tabDatos.Focus();
        }

        private void cboxPadrino_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConsultaApadrinado.IsEnabled = true;
        }

        private void txtboxPesoPerro_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtEdadPerro_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtboxTelefonoVoluntario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtboxTelefonoSocio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtIBAN2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtIBAN3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtIBAN4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtIBAN5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtIBAN6_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;
        }

        private void txtCuantia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;
        }
    }
}
