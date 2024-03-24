using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {

        [DisplayName("Id")]
        public int artid { get; set; }

        [DisplayName("Código")]
        public string artcodigo { get; set; }

        [DisplayName("Nombre")]
        public string artnombre { get; set; }

        [DisplayName("Descripción")]
        public string artdescripcion { get; set; }

        [DisplayName("Marca")]
        public Marca artmarca { get; set; }

        [DisplayName("Categoría")]
        public Categoria artcategoria { get; set; }

        [DisplayName("Precio")]
        public decimal artprecio { get; set; }

        public string artimagen { get; set; }

        [DisplayName("Estado")]
        public bool artestado { get; set; }

        [DisplayName("Fav")]
        public string artfav { get; set; }

    }
}





