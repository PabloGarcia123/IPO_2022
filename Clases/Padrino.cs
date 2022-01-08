using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProyectoIPO2020_2021
{
    public class Padrino
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string dni { set; get; }
        public string correo { set; get; }
        public int n_tlf { set; get; }
        public int aportacion { set; get; }
        public string forma_pago { set; get; }
        public long n_cuenta { set; get; }
        public DateTime fecha_apadrinamiento { set; get; }
        public BitmapImage img { set; get; }

        public Padrino(string nombre, string apellido, string dni, string correo, int n_tlf, int aportacion, string forma_pago, long n_cuenta, DateTime fecha_apadrinamiento, BitmapImage img)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
            this.n_tlf = n_tlf;
            this.aportacion = aportacion;
            this.forma_pago = forma_pago;
            this.n_cuenta = n_cuenta;
            this.fecha_apadrinamiento = fecha_apadrinamiento;
            this.img = img;
        }
    }
}
