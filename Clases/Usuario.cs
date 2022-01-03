using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProyectoIPO2020_2021.Clases
{
    public class Usuario
    {
        public string nombre { set; get; }
        public string correo { set; get; }
        public string dni { set; get; }
        public int n_tlf { set; get; }
        public DateTime ult_acceso { set; get; }
        public BitmapImage img { set; get; }
        public string contraseña { set; get; }

        public Usuario(string nombre, string correo, string dni, int n_tlf, DateTime ult_acceso, BitmapImage img, string contraseña)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.dni = dni;
            this.n_tlf = n_tlf;
            this.ult_acceso = DateTime.Now;
            this.img = img;
            this.contraseña = contraseña;
        }
    }

    
    
}
