using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo : ICloneable
    {
        //Articulo.cs tiene 8 variables, entre ellas dos (*) con un tipo de dato personalizado (Marca.cs y Categoria.cs)
        //DisplayName lo usamos para cambiar el titulo del elemento que se mostrará en la tabla del programa (Si no hacemos esto, el titulo será "artcodigo", "artnombre", etc...

        //Código de artículo
        //Nombre
        //Descripción
        //Marca     (*)
        //Categoría (*)
        //Imagen
        //Precio

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



        //  Al igualar un Articulo con otro art1 = art2,  cuando se modifica una propiedad de uno se modifica la del otro. Entonces si quremos hacer esto pero que nos lo haga como una instancia distinta
        //  Usamos el Clone.
        //  Este metododo clone dentro del articulo nos sirve para clonarlo y que sus propiedades NO hagan referencia al otro articulo
        public object Clone()
    {
        var clonedArticle = new Articulo
        {
            artid = artid,
            artcodigo = artcodigo,
            artnombre = artnombre,
            artdescripcion = artdescripcion,
            artmarca = artmarca,
            artcategoria = artcategoria,
            artprecio = artprecio,
            artimagen = artimagen
        };
        return clonedArticle;
    }
    }
}





