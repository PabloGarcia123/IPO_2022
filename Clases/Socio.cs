using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO2020_2021
{
    class Socio
    {
        public string nombre { set; get; }
        public string dni { set; get; }
        public string correo { set; get; }
        public int n_tlf { set; get; }
        public int n_cuenta { set; get; }
        public string ent_bancaria { set; get; }
        public string metodo_pago { set; get; }
        public string img { set; get; }

        public Socio(string nombre, string dni, string correo, int n_tlf, int n_cuenta, string ent_bancaria, string metodo_pago, string img)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.correo = correo;
            this.n_tlf = n_tlf;
            this.n_cuenta = n_cuenta;
            this.ent_bancaria = ent_bancaria;
            this.metodo_pago = metodo_pago;
            this.img = img;
        }

       
    }
}
