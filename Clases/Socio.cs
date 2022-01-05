using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int IBAN1 { set; get; }
        public int IBAN2 { set; get; }
        public int IBAN3 { set; get; }
        public int IBAN4 { set; get; }
        public int IBAN5 { set; get; }
        public int IBAN6 { set; get; }
        public int cuantia { set; get; }
        public string metodo_pago { set; get; }
        public string img { set; get; }

        public Socio(string nombre, string apellido, string dni, int n_tlf, string correo, string ent_bancaria, int IBAN1, int IBAN2, int IBAN3, int IBAN4, int IBAN5, int IBAN6, int cuantia, string metodo_pago, string img)
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
