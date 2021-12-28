using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO2020_2021
{
    class Voluntario
    {
        public String nombre { set; get; }
        public String dni { set; get; }
        public String correo { set; get; }
        public int n_tlf { set; get; }
        public String horario { set; get; }
        public String zona { set; get; }
        public String img { set; get; }

        public Voluntario(string nombre, string dni, string correo, int n_tlf, string horario, string zona, string img)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.correo = correo;
            this.n_tlf = n_tlf;
            this.horario = horario;
            this.zona = zona;
            this.img = img;
        }

       


    }
}
