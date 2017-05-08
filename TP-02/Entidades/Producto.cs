using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    ///
   
    public abstract class Producto
    {
      
       public EMarca _marca;
       public string _codigoDeBarras;
       public ConsoleColor _colorPrimarioEmpaque;

       public enum EMarca
       {
           Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
       }

       public Producto() { }

       public Producto(EMarca marca, string codigoDeBarra, ConsoleColor color):this()
       {
           this._marca = marca;
           this._codigoDeBarras = codigoDeBarra;
           this._colorPrimarioEmpaque = color;
       }
        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public   abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CODIGO DE BARRAS: " + _codigoDeBarras);
            sb.AppendLine("MARCA          : " + _marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + _colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");
            return sb.ToString();
            
        }

        public static explicit operator string(Producto p)
        {
          return  p.Mostrar().ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras) ;
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
    }
}
