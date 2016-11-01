using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Estante
    {
        private sbyte _capacidad;
        private List<Producto> _productos;

        private Estante()
        {
            _productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
            _productos = new List<Producto>(_capacidad);

        }

        public float ValorEstanteTotal
        {
            get
            {
                return GetValorEstante();
            }
        }

        public List<Producto> GetProductos()
        {
            return this._productos;

        }

        private float GetValorEstante()
        {

            return GetValorEstante(Producto.ETipoProducto.Todos);

        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float sumaGalletita = 0, sumaHarina = 0, sumaGaseosa = 0, sumaJugo = 0, total = 0;
            if (tipo == Producto.ETipoProducto.Galletita)
            {
                sumaGalletita = (float)tipo;
            }
            if (tipo == Producto.ETipoProducto.Harina)
            {
                sumaHarina = (float)tipo;
            }

            if (tipo == Producto.ETipoProducto.Gaseosa)
            {
                sumaGaseosa = (float)tipo;
            }
            if (tipo == Producto.ETipoProducto.Jugo)
            {
                sumaJugo = (float)tipo;
            }
            total = sumaGalletita + sumaGaseosa + sumaJugo;
            return total;
        }
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CAPACIDAD: " + e._capacidad);
            foreach (Producto item in e._productos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }

        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        }

        public static bool operator ==(Estante e, Producto prod)
        {
            foreach (Producto item in e._productos)
            {
                if (e._productos.Equals(item))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Este metodo tiene que retornar el estante sin
        /// el elemento que es igual  pero eso es lo que m
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            // int indice = -1;
            foreach (Producto item in e._productos)
            {
                if (item is Producto && e._capacidad.Equals(tipo))
                {

                    return e;

                }

            }

            return e;

        }
        public static Estante operator -(Estante e, Producto prod)
        {
            //if (e != prod)
            //{
            //    e._producto.Remove(prod);
            //}
            //return e;
            if (e == prod)
            {
                return e;
            }
            return e;
        }

        public static bool operator +(Estante e, Producto prod)
        {
            if (e._productos.Count <= e._capacidad)
            {
                if (e != prod)
                {
                    return true;

                }

            }
            return false;
        }



    }
}
