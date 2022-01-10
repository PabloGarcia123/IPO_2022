using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProyectoIPO2020_2021.Clases
{
    class Socio
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string dni { set; get; }
        public int n_tlf { set; get; }
        public string correo { set; get; }
        public string ent_bancaria { set; get; }
        public string IBAN1 { set; get; }
        public int IBAN2 { set; get; }
        public int IBAN3 { set; get; }
        public int IBAN4 { set; get; }
        public int IBAN5 { set; get; }
        public int IBAN6 { set; get; }
        public double cuantia { set; get; }
        public string metodo_pago { set; get; }
        public ImageSource img { set; get; }

        public Socio()
        {

        }
        public Socio(string nombre, string apellido, string dni, int n_tlf, string correo, string ent_bancaria, string IBAN1, int IBAN2, int IBAN3, int IBAN4, int IBAN5, int IBAN6, double cuantia, string metodo_pago, ImageSource img)
        {

            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.n_tlf = n_tlf;
            this.correo = correo;
            this.ent_bancaria = ent_bancaria;
            this.IBAN1 = IBAN1;
            this.IBAN2 = IBAN2;
            this.IBAN3 = IBAN3;
            this.IBAN4 = IBAN4;
            this.IBAN5 = IBAN5;
            this.IBAN6 = IBAN6;
            this.cuantia = cuantia;
            this.metodo_pago = metodo_pago;
            this.img = img;
        }

       
    }
}
