using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProyectoIPO2020_2021.Access
{
    public class Conexion
    {
        protected OleDbConnection conexion;

        protected OleDbConnection ConexionBD
        {
            get
            {
                conexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BBDDPerros.accdb;Persist Security Info=True");
                conexion.Open();
                return conexion;
            }
        }
    }
}
