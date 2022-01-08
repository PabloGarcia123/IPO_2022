using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProyectoIPO2020_2021.Clases
{
    class Perro 
    {
        public string nombre { set; get; }
        public string sexo { set; get; }
        public string raza { set; get; }
        public string peso { set; get; }
        public string edad { set; get; }
        public string fecha_entrada { set; get; }
        public bool apadrinado { set; get; }
        public string descripcion { set; get; }
        public ImageSource img { set; get; }



        public Perro(string nombre, string sexo, string raza, string peso, string edad, string fecha_entrada, bool apadrinado, string descripcion, ImageSource img)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.peso = peso;
            this.edad = edad;
            this.fecha_entrada = fecha_entrada;
            this.apadrinado = apadrinado;
            this.descripcion = descripcion;
            this.img = img;
        }

    }
}
