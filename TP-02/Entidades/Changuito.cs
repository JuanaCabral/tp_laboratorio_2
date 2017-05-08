using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
 
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed  class Changuito
    {
      public   List<Producto> _productos;
      public  int _espacioDisponible;

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #region "Constructores"
        private Changuito()
        {
            _productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// Aca agrege el if para que compare el elemnto de la lista si es del mismo tipo
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public  string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles" , c._productos.Count , c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(v is Snacks)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c._productos.Count < c._espacioDisponible)
            {
                foreach (Producto v in c._productos)
                {
                    if (v == p)
                        return c;
                    break;
                }

                c._productos.Add(p);
                
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    c._productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
