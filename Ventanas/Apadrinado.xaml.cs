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

namespace ProyectoIPO2020_2021
{
    /// <summary>
    /// Lógica de interacción para Apadrinado.xaml
    /// </summary>
    
    public partial class Apadrinado : Window
    {
        private static BitmapImage imgPadrino1 = new BitmapImage(new Uri("/Images/George.png", UriKind.Relative));
        private static BitmapImage imgPadrino2 = new BitmapImage(new Uri("/Images/Roz.png", UriKind.Relative));
        private static BitmapImage imgPadrino3 = new BitmapImage(new Uri("/Images/Henry.png", UriKind.Relative));
        //private Aplicacion ventanaApp = new Aplicacion();
        public static Padrino padrino1 = new Padrino("Lorenzo", "Galván Moreno", "05980126D", "Lorenzo.Galvan@gmail.com", 664231235, 50, "Efectivo", 01289193000244163980, DateTime.Now, imgPadrino1);
        public static Padrino padrino2 = new Padrino("Sheila", "Soria Pozo", "05986526D", "Sheila.Soria@gmail.com", 652345633, 100, "Transferencia Bancaria", 0002252228352538144762, DateTime.Now, imgPadrino2);
        public static Padrino padrino3 = new Padrino("Sergio", "Mateu-Belmonte", "05123126D", "Sergio.Mateu@gmail.com", 678453456, 85, "Bizum", 0002252228456784344762, DateTime.Now, imgPadrino3);

      

        public Apadrinado()
        {
            InitializeComponent();

            //ventanaApp.cargarPadrinos();
            
            

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
