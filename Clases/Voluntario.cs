using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO2020_2021
{
    class Voluntario
    {
        public string nombre { set; get; }
        public string dni { set; get; }
        public string correo { set; get; }
        public int n_tlf { set; get; }
        public string horario { set; get; }
        public string zona { set; get; }
        public string img { set; get; }

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
