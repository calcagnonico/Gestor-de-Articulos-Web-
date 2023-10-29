using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        //Categoria tiene 2 variables (Id y Descripcion)
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //En la DataGridView de los articulos cuando le decimos que muestre la Marca tenemos que decirle que muestre la Descripcion (Marca tiene Id y Descripcion)
        //Si no le decimos nada mostrara "dominio.Marca" en todos los articulos
        //Entonces con el siguiente override le decimos que el return sea la Descripcion
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
