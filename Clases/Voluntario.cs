using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProyectoIPO2020_2021.Clases
{
    class Voluntario
    {
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string dni { set; get; }
        public int n_tlf { set; get; }
        public string correo { set; get; }
        public bool conocimientos { set; get; }
        public string disponibilidad { set; get; }
        public ImageSource img { set; get; }

        public Voluntario(string nombre, string apellido, string dni, int n_tlf,string correo,bool conocimientos, string disponibilidad, ImageSource img)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.n_tlf = n_tlf;
            this.correo = correo;
            this.conocimientos = conocimientos;
            this.disponibilidad = disponibilidad;
            this.img = img;
        }

       


    }
}
