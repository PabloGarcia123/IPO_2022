using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIPO2020_2021
{
    class Perro
    {
        public String nombre { set; get; }
        public Boolean sexo { set; get; }
        public String raza { set; get; }
        public int peso { set; get; }
        public int edad { set; get; }
        public DateTime fecha_entrada { set; get; }
        public String estado { set; get; }
        public Boolean apadrinado { set; get; }
        public String descripcion { set; get; }
        public String img { set; get; }

        public Perro(string nombre, bool sexo, string raza, int peso, int edad, DateTime fecha_entrada, string estado, bool apadrinado, string descripcion, string img)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.raza = raza;
            this.peso = peso;
            this.edad = edad;
            this.fecha_entrada = fecha_entrada;
            this.estado = estado;
            this.apadrinado = apadrinado;
            this.descripcion = descripcion;
            this.img = img;
        }
    }
}
