using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public abstract class Producto
    {

        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public Producto()
        { }

        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
            : this()
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;


        }
        public enum ETipoProducto
        {
            Harina, Galletita, Gaseosa, Jugo, Todos
        }
        public enum EMarcaProducto
        {
            Favorita, Pitusas, Diversión, Naranjú, Swift
        }
        public abstract float CalcularCostoDeProducto { get; }


        public EMarcaProducto Marca { get { return this._marca; } }


        public float Precio { get { return this._precio; } }


        public virtual string Consumir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PARTE DE UNA MEZCLA");
            return sb.ToString();
        }
        public bool Equals(object obj)
        {
            // if (obj is Galletita) return true; if (obj is Gaseosa) return true; if (obj is Harina) return true; if (obj is Jugo) return true; return false;

            if (ReferenceEquals(null, obj)) return false; if (obj.GetType() == this.GetType()) return true; return false;
        }

        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }
        /// <summary>
        /// el implicit LLama al mostrar que ya retorna una cadena de caracteres
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public static implicit operator string(Producto p)
        {

            return MostrarProducto(p);
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MARCA: " + p._marca.ToString());
            sb.AppendLine("CODIGO DE BARRA: " + p._codigoBarra.ToString());
            sb.AppendLine("PRECIO: " + p._precio.ToString());
            return sb.ToString();
        }



        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            return (prodUno._marca == marca);
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }
        /// <summary>
        /// Comparo y reutilizo el metodo Equal para comparar dos objetos son iguales
        /// </summary>
        /// <param name="prodUno"></param>
        /// <param name="prodDos"></param>
        /// <returns></returns>
        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            return (prodUno._codigoBarra == prodDos._codigoBarra && prodUno._marca == prodDos._marca && prodUno.Equals(prodDos));

        }
        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }
    }
}
